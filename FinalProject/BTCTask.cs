using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace BTCTaskProject
{
    public class RSI_struct 
    {
        public double averageUP;
        public double averageDOWN;
        public double RSI;
        public RSI_struct(double up, double down, double rsi) 
        {
            averageUP = up;
            averageDOWN = down;
            RSI = rsi;
        }
    }
    public class MACD_struct 
    {
        public double EMA1;
        public double EMA2;
        public double MACD1;
        public MACD_struct(double ema1, double ema2, double macd1) 
        {
            EMA1 = ema1;
            EMA2 = ema2;
            MACD1 = macd1;
        }
    }
    public class KDJ_struct 
    {
        public double K;
        public double D;
        public double RSV;
        public KDJ_struct(double k, double d, double rsv) 
        {
            K = k;
            D = d;
            RSV = rsv;
        }
    }
    public class KLineData
    {
        public double StartPrice;
        public double MaxPrice;
        public double MinPrice;
        public double EndPrice;
        public double TradeAmount;
        public Version DataVersion;

        public KLineData(double sPrice, double maxPrice, double minPrice, double ePrice, double ta, Version datav)
        {
            StartPrice = sPrice;
            MaxPrice = maxPrice;
            MinPrice = minPrice;
            EndPrice = ePrice;
            TradeAmount = ta;
            DataVersion = datav;
        }
    }

    public enum Version
    { 
        One_Min,
        One_Hour,
        fifteen_Min,
        Unknown
    }
    public enum ErrorCode
    {
        WrongFile,
        None
    }

    public class BTCTask 
    {
        public Graphics g;
        public Version version = Version.Unknown;
        public List<KLineData> Entity_15m = new List<KLineData>();
        public List<KLineData> Entity_1m = new List<KLineData>();
        public List<KLineData> Entity_1h = new List<KLineData>();
        public PointF range_1m = new PointF(0, 1000000);
        public PointF range_15m = new PointF(0, 1000000);
        public PointF range_1h = new PointF(0, 1000000);
        public int LineNum;
        public Size PrintSize;
        public PointF KLineMapping1m;
        public PointF KLineMapping15m;
        public PointF KLineMapping1h;
        public int MaxKLineNum1m;
        public int MaxKLineNum15m;
        public int MaxKLineNum1h;
        public BTCTask(Graphics gIn, Size PS)
        {
            g = gIn;
            PrintSize = PS;
            LineNum = PrintSize.Width;
        }

        public ErrorCode LoadTaskFile() 
        {
            string filename = "";
            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        filename = "binance_BTCUSDT_data_1minute.csv";
                        version = Version.One_Min;
                        break;
                    case 1:
                        filename = "binance_BTCUSDT_data_15minute.csv";
                        version = Version.fifteen_Min;
                        break;
                    case 2:
                        filename = "binance_BTCUSDT_data_1hour.csv";
                        version = Version.One_Hour;
                        break;
                }
                StreamReader TaskText = new StreamReader(filename);
                String[] Piecewise;
                String CurLine;
                CurLine = TaskText.ReadLine();
                while (TaskText.Peek() >= 0)
                {
                    CurLine = TaskText.ReadLine();
                    Piecewise = CurLine.Trim().Split(',');
                    switch (version)
                    {
                        case Version.One_Min:
                            Entity_1m.Add(new KLineData(Convert.ToDouble(Piecewise[2]), Convert.ToDouble(Piecewise[3]), Convert.ToDouble(Piecewise[4]), Convert.ToDouble(Piecewise[5]), Convert.ToDouble(Piecewise[6]), version));
                            break;
                        case Version.One_Hour:
                            Entity_1h.Add(new KLineData(Convert.ToDouble(Piecewise[2]), Convert.ToDouble(Piecewise[3]), Convert.ToDouble(Piecewise[4]), Convert.ToDouble(Piecewise[5]), Convert.ToDouble(Piecewise[6]), version));
                            break;
                        case Version.fifteen_Min:
                            Entity_15m.Add(new KLineData(Convert.ToDouble(Piecewise[2]), Convert.ToDouble(Piecewise[3]), Convert.ToDouble(Piecewise[4]), Convert.ToDouble(Piecewise[5]), Convert.ToDouble(Piecewise[6]), version));
                            break;
                    }
                }  
            }
            return ErrorCode.None;
        }

        public void draw(int num) 
        {
            calculateLim();
            int tmp;
            MaxKLineNum1m = (Entity_1m.Count > LineNum) ? LineNum : Entity_1m.Count;
            KLineMapping1m.X = PrintSize.Width / MaxKLineNum1m;
            KLineMapping1m.Y = PrintSize.Height / (range_1m.X - range_1m.Y);
            KLineMapping1m.Y = Convert.ToSingle(KLineMapping1m.Y * 0.8);
            MaxKLineNum15m = (Entity_15m.Count > LineNum) ? LineNum : Entity_15m.Count;
            KLineMapping15m.X = PrintSize.Width / MaxKLineNum15m;
            KLineMapping15m.Y = PrintSize.Height / (range_15m.X - range_15m.Y);
            KLineMapping15m.Y = Convert.ToSingle(KLineMapping15m.Y * 0.8);
            MaxKLineNum1h = (Entity_1h.Count > LineNum) ? LineNum : Entity_1h.Count;
            KLineMapping1h.X = PrintSize.Width / MaxKLineNum1h;
            KLineMapping1h.Y = PrintSize.Height / (range_1h.X - range_1h.Y);
            KLineMapping1h.Y = Convert.ToSingle(KLineMapping1h.Y * 0.8);
            int ysizeMax;
            int ysize;
            String drawMax;
            String drawMin;
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            StringFormat drawFormat = new StringFormat();
            switch (num) 
            {
                case 1:
                    tmp = 0;
                    drawMax = ((int)range_1m.X).ToString();
                    drawMin = ((int)range_1m.Y).ToString();
                    g.DrawString(drawMax, drawFont, drawBrush, 850, 0, drawFormat);
                    g.DrawString(drawMin, drawFont, drawBrush, 850, 250, drawFormat);
                    for (int i = (Entity_1m.Count - MaxKLineNum1m); i < Entity_1m.Count; i++) 
                    {
                        KLineData k = (KLineData)Entity_1m[i];
                        ysizeMax = (int)(PrintSize.Height * 0.9 - (k.MaxPrice - range_1m.Y) * KLineMapping1m.Y);
                        g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(new Point(tmp + (int)(KLineMapping1m.X / 4), ysizeMax), new Size((int)(KLineMapping1m.X * 0.5), (int)(PrintSize.Height * 0.9 - (k.MinPrice - range_1m.Y) * KLineMapping1m.Y) - ysizeMax)));
                        if (k.StartPrice >= k.EndPrice)
                        {
                            ysize = (int)(PrintSize.Height * 0.9 - (k.StartPrice - range_1m.Y) * KLineMapping1m.Y);
                            g.FillRectangle(new SolidBrush(Color.Red), new Rectangle(new Point(tmp, ysize), new Size((int)KLineMapping1m.X, (int)(PrintSize.Height * 0.9 - (k.EndPrice - range_1m.Y) * KLineMapping1m.Y) - ysize)));
                        }
                        else 
                        {
                            ysize = (int)(PrintSize.Height * 0.9 - (k.EndPrice - range_1m.Y) * KLineMapping1m.Y);
                            g.FillRectangle(new SolidBrush(Color.Green), new Rectangle(new Point(tmp, ysize), new Size((int)KLineMapping1m.X, (int)(PrintSize.Height * 0.9 - (k.StartPrice - range_1m.Y) * KLineMapping1m.Y) - ysize)));
                        }
                        tmp = tmp + (int)KLineMapping1m.X;
                    }
                    break;
                case 2:
                    tmp = 0;
                    drawMax = ((int)range_15m.X).ToString();
                    drawMin = ((int)range_15m.Y).ToString();
                    g.DrawString(drawMax, drawFont, drawBrush, 850, 0, drawFormat);
                    g.DrawString(drawMin, drawFont, drawBrush, 850, 250, drawFormat);
                    for (int i = (Entity_15m.Count - MaxKLineNum15m); i < Entity_15m.Count; i++)
                    {
                        KLineData k = (KLineData)Entity_15m[i];
                        ysizeMax = (int)(PrintSize.Height * 0.9 - (k.MaxPrice - range_15m.Y) * KLineMapping15m.Y);
                        g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(new Point(tmp + (int)(KLineMapping15m.X / 4), ysizeMax), new Size((int)(KLineMapping15m.X * 0.5), (int)(PrintSize.Height * 0.9 - (k.MinPrice - range_15m.Y) * KLineMapping15m.Y) - ysizeMax)));
                        if (k.StartPrice >= k.EndPrice)
                        {
                            ysize = (int)(PrintSize.Height * 0.9 - (k.StartPrice - range_15m.Y) * KLineMapping15m.Y);
                            g.FillRectangle(new SolidBrush(Color.Red), new Rectangle(new Point(tmp, ysize), new Size((int)KLineMapping15m.X, (int)(PrintSize.Height * 0.9 - (k.EndPrice - range_15m.Y) * KLineMapping15m.Y) - ysize)));
                        }
                        else 
                        {
                            ysize = (int)(PrintSize.Height * 0.9 - (k.EndPrice - range_15m.Y) * KLineMapping15m.Y);
                            g.FillRectangle(new SolidBrush(Color.Green), new Rectangle(new Point(tmp, ysize), new Size((int)KLineMapping15m.X, (int)(PrintSize.Height * 0.9 - (k.StartPrice - range_15m.Y) * KLineMapping15m.Y) - ysize)));
                        }
                        tmp = tmp + (int)KLineMapping15m.X;
                    }
                    break;
                case 3:
                    tmp = 0;
                    drawMax = ((int)range_1h.X).ToString();
                    drawMin = ((int)range_1h.Y).ToString();
                    g.DrawString(drawMax, drawFont, drawBrush, 850, 0, drawFormat);
                    g.DrawString(drawMin, drawFont, drawBrush, 850, 250, drawFormat);
                    for (int i = (Entity_1h.Count - MaxKLineNum1h); i < Entity_1h.Count; i++)
                    {
                        KLineData k = (KLineData)Entity_1h[i];
                        ysize = (int)(PrintSize.Height * 0.9 - (k.StartPrice - range_1h.Y) * KLineMapping1h.Y);
                        ysizeMax = (int)(PrintSize.Height * 0.9 - (k.MaxPrice - range_1h.Y) * KLineMapping1h.Y);
                        g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(new Point(tmp + (int)(KLineMapping1h.X / 4), ysizeMax), new Size((int)(KLineMapping1h.X * 0.5), (int)(PrintSize.Height * 0.9 - (k.MinPrice - range_1h.Y) * KLineMapping1h.Y) - ysizeMax)));
                        if (k.StartPrice > k.EndPrice)
                        {
                            ysize = (int)(PrintSize.Height * 0.9 - (k.StartPrice - range_1h.Y) * KLineMapping1h.Y);
                            g.FillRectangle(new SolidBrush(Color.Red), new Rectangle(new Point(tmp, ysize), new Size((int)KLineMapping1h.X, (int)(PrintSize.Height * 0.9 - (k.EndPrice - range_1h.Y) * KLineMapping1h.Y) - ysize)));
                        }
                        else 
                        {
                            ysize = (int)(PrintSize.Height * 0.9 - (k.EndPrice - range_1h.Y) * KLineMapping1h.Y);
                            g.FillRectangle(new SolidBrush(Color.Green), new Rectangle(new Point(tmp, ysize), new Size((int)KLineMapping1h.X, (int)(PrintSize.Height * 0.9 - (k.StartPrice - range_1h.Y) * KLineMapping1h.Y) - ysize)));
                        }
                        tmp = tmp + (int)KLineMapping1h.X;
                    }
                    break;
            }
        }
        public int Linenum
        {
            set
            {
                if (value > PrintSize.Width)
                    value = PrintSize.Width;
                if (value < 3)
                    value = 2;
                this.LineNum = value;
            }
        }
        public void calculateLim() 
        {
            range_1m = new PointF(0, 1000000);
            range_15m = new PointF(0, 1000000);
            range_1h = new PointF(0, 1000000);
            for (int i = (Entity_1m.Count - MaxKLineNum1m); i < Entity_1m.Count; i++) 
            {
                KLineData k = (KLineData)Entity_1m[i];
                range_1m.X = (k.MaxPrice > range_1m.X) ? Convert.ToSingle(k.MaxPrice) : range_1m.X;
                range_1m.Y = (k.MinPrice < range_1m.Y) ? Convert.ToSingle(k.MinPrice) : range_1m.Y;
            }
            for (int i = (Entity_15m.Count - MaxKLineNum15m); i < Entity_15m.Count; i++)
            {
                KLineData k = (KLineData)Entity_15m[i];
                range_15m.X = (k.MaxPrice > range_15m.X) ? Convert.ToSingle(k.MaxPrice) : range_15m.X;
                range_15m.Y = (k.MinPrice < range_15m.Y) ? Convert.ToSingle(k.MinPrice) : range_15m.Y;

            }
            for (int i = (Entity_1h.Count - MaxKLineNum1h); i < Entity_1h.Count; i++)
            {
                KLineData k = (KLineData)Entity_1h[i];
                range_1h.X = (k.MaxPrice > range_1h.X) ? Convert.ToSingle(k.MaxPrice) : range_1h.X;
                range_1h.Y = (k.MinPrice < range_1h.Y) ? Convert.ToSingle(k.MinPrice) : range_1h.Y;
            }
        }
    }

    public class DataEntity 
    {
        protected Graphics g;
        protected BTCTask tmp_btctask;
        public virtual void Draw(out List<int> BuyPoint, out List<int> SellPoint, out List<KLineData> Kldata) 
        {
            BuyPoint = new List<int>();
            SellPoint = new List<int>();
            Kldata = new List<KLineData>();
        }
        public void DrawData() 
        {
            Draw(out List<int> BuyPoint, out List<int> SellPoint, out List<KLineData> Kldata);
            int xgap = 0;
            int xposition;
            int xMove = 0;
            switch (Kldata[0].DataVersion)
            {
                case Version.One_Min:
                    xgap = (int)tmp_btctask.KLineMapping1m.X;
                    xMove = (tmp_btctask.Entity_1m.Count - tmp_btctask.MaxKLineNum1m);
                    break;
                case Version.fifteen_Min:
                    xgap = (int)tmp_btctask.KLineMapping15m.X;
                    xMove = (tmp_btctask.Entity_15m.Count - tmp_btctask.MaxKLineNum15m);
                    break;
                case Version.One_Hour:
                    xgap = (int)tmp_btctask.KLineMapping1h.X;
                    xMove = (tmp_btctask.Entity_1h.Count - tmp_btctask.MaxKLineNum1h);
                    break;
            }
            for (int i = 0; i < BuyPoint.Count; i++)
            {
                xposition = xgap * (BuyPoint[i] - xMove);
                g.FillRectangle(new SolidBrush(Color.Green), new Rectangle(new Point(xposition, 0), new Size(xgap, 30)));
            }
            for (int i = 0; i < SellPoint.Count; i++)
            {
                xposition = xgap * (SellPoint[i] - xMove);
                g.FillRectangle(new SolidBrush(Color.Red), new Rectangle(new Point(xposition, 0), new Size(xgap, 30)));
            }
        }
    }
    interface control
    {
        void draw();
        void calculate();
    }
    public class MACD_Data : DataEntity, control
    {
        public List<MACD_struct> MACD = new List<MACD_struct>();
        public int EMA1_NUM = 5;
        public int EMA2_NUM = 20;
        List<KLineData> KLdata = new List<KLineData>();
        List<int> buyPoint = new List<int>();
        List<int> sellPoint = new List<int>();

        public MACD_Data(Graphics gIn, List<KLineData> kldata, object d) //計算數值
        {
            g = gIn;
            tmp_btctask = (BTCTask) d;
            KLdata = kldata;
            double tmp_ema1 = 0;
            double tmp_ema2 = 0;
            double tmp_macd = 0;
            int x = 1;
            for (int i = 0; i < EMA2_NUM; i++)
            {
                KLineData currentKLdata = (KLineData)KLdata[i];
                if (i == EMA1_NUM)
                {
                    tmp_ema1 = currentKLdata.EndPrice;
                    MACD.Add(new MACD_struct(tmp_ema1, tmp_ema2, tmp_macd));
                }
                else if (i > EMA1_NUM)
                {
                    tmp_ema1 = (tmp_ema1 * (EMA1_NUM - 1) + currentKLdata.EndPrice * 2) / (EMA1_NUM + 1);
                    MACD.Add(new MACD_struct(tmp_ema1, tmp_ema2, tmp_macd));
                }
                else 
                {
                    MACD.Add(new MACD_struct(tmp_ema1, tmp_ema2, tmp_macd));
                }
            }
            for (int i = EMA2_NUM; i < KLdata.Count; i++) 
            {
                KLineData currentKLdata = (KLineData)KLdata[i];
                if (i == EMA2_NUM)
                {
                    tmp_ema1 = (tmp_ema1 * (EMA1_NUM - 1) + currentKLdata.EndPrice * 2) / (EMA1_NUM + 1);
                    tmp_ema2 = currentKLdata.EndPrice;
                    tmp_macd = (tmp_ema1 - tmp_ema2) * 2 / (x + 1);
                    MACD.Add(new MACD_struct(tmp_ema1, tmp_ema2, tmp_macd));
                }
                else 
                {
                    tmp_ema1 = (tmp_ema1 * (EMA1_NUM - 1) + currentKLdata.EndPrice * 2) / (EMA1_NUM + 1);
                    tmp_ema2 = (tmp_ema2 * (EMA2_NUM - 1) + currentKLdata.EndPrice * 2) / (EMA2_NUM + 1);
                    tmp_macd = (tmp_macd * (x - 1) + (tmp_ema1 - tmp_ema2) * 2) / (x + 1);
                    MACD.Add(new MACD_struct(tmp_ema1, tmp_ema2, tmp_macd));
                }
                x++;
            }
        }
        public void draw() //標記買賣點位置
        {
            calculate();
            DrawData();
        }
        public override void Draw(out List<int> BuyPoint, out List<int> SellPoint, out List<KLineData> Kldata) 
        {
            BuyPoint = buyPoint;
            SellPoint = sellPoint;
            Kldata = KLdata;
        }
        public void calculate() //計算買賣點
        {
            bool situation;
            situation = (MACD[0].EMA1 > MACD[0].EMA2) ? false : true;
            for (int i = 1; i < MACD.Count; i++) 
            {
                if (situation == false)
                {
                    if (MACD[i].EMA2 > MACD[i].EMA1) 
                    {
                        sellPoint.Add(i);
                        situation = true;
                    }
                }
                else 
                {
                    if (MACD[i].EMA1 > MACD[i].EMA2)
                    {
                        buyPoint.Add(i);
                        situation = false;
                    }
                }
            }
        }
    }
    public class KDJ_Data : DataEntity, control
    {
        public List<KDJ_struct> KDJ = new List<KDJ_struct>();
        List<KLineData> KLdata = new List<KLineData>();
        List<int> buyPoint = new List<int>();
        List<int> sellPoint = new List<int>();
        public KDJ_Data(Graphics gIn, List<KLineData> kldata, object d) //計算數值
        {
            g = gIn;
            tmp_btctask = (BTCTask)d;
            KLdata = kldata;
            double tmp_K = 0;
            double tmp_D = 0;
            double rsv = 0;
            double rsv_min = 0;
            double rsv_max = 0;
            int RSV_NUM = 5;
            for (int i = 0; i < RSV_NUM; i++)
            {
                KLineData currentKLdata = (KLineData)KLdata[i];
                if (i == 0)
                {
                    rsv_min = currentKLdata.MinPrice;
                    rsv_max = currentKLdata.MaxPrice;
                }
                else 
                {
                    rsv_min = (currentKLdata.MinPrice < rsv_min) ? currentKLdata.MinPrice : rsv_min;
                    rsv_max = (currentKLdata.MaxPrice > rsv_max) ? currentKLdata.MaxPrice : rsv_max;
                }
                KDJ.Add(new KDJ_struct(tmp_K, tmp_D, rsv));
            }
            for (int i = RSV_NUM; i < KLdata.Count; i++) 
            {
                KLineData currentKLdata = (KLineData)KLdata[i];
                rsv_min = (currentKLdata.MinPrice < rsv_min) ? currentKLdata.MinPrice : rsv_min;
                rsv_max = (currentKLdata.MaxPrice > rsv_max) ? currentKLdata.MaxPrice : rsv_max;
                rsv = (currentKLdata.EndPrice - rsv_min) * 100 / (rsv_max - rsv_min);
                tmp_K = (tmp_K * 2 / 3) + (rsv / 3);
                tmp_D = (tmp_D * 19 / 20) + (tmp_K / 20);
                KDJ.Add(new KDJ_struct(tmp_K, tmp_D, rsv));
            }
        }
        public void calculate() //計算買賣點
        {
            bool situation;
            situation = (KDJ[0].K > KDJ[0].D) ? false : true;
            for (int i = 1; i < KDJ.Count; i++) 
            {
                if (situation == false)
                {
                    if (KDJ[i].K < KDJ[i].D)
                    {
                        sellPoint.Add(i);
                        situation = true;
                    }
                }
                else
                {
                    if (KDJ[i].K > KDJ[i].D)
                    {
                        buyPoint.Add(i);
                        situation = false;
                    }
                }
            }
        }
        public override void Draw(out List<int> BuyPoint, out List<int> SellPoint, out List<KLineData> Kldata)
        {
            BuyPoint = buyPoint;
            SellPoint = sellPoint;
            Kldata = KLdata;
        }
        public void draw() //標記買賣點位置
        {
            calculate();
            DrawData();
        }
    }
    public class RSI_Data : DataEntity, control
    {
        public List<RSI_struct> RSI = new List<RSI_struct>();
        public int RSI_NUM = 5;
        List<KLineData> KLdata = new List<KLineData>();
        List<int> buyPoint = new List<int>();
        List<int> sellPoint = new List<int>();
        public RSI_Data(Graphics gIn, List<KLineData> kldata, object d) //計算數值
        {
            g = gIn;
            KLdata = kldata;
            tmp_btctask = (BTCTask) d;
            double tmp_UP = 0;
            double tmp_down = 0;
            double tmp_rsi = 0;
            double totalUP = 0;
            double totalDOWN = 0;
            double last_data = 0;

            for (int i = 0; i < RSI_NUM; i++) 
            {
                KLineData currentKLdata = (KLineData)KLdata[i];
                RSI.Add(new RSI_struct(tmp_UP, tmp_down, tmp_rsi));
                if (currentKLdata.StartPrice > currentKLdata.EndPrice)
                {
                    totalDOWN = totalDOWN + (currentKLdata.StartPrice - currentKLdata.EndPrice);
                }
                else 
                {
                    totalUP = totalUP + (currentKLdata.EndPrice - currentKLdata.StartPrice);
                }

            }
            for (int i = RSI_NUM; i < KLdata.Count; i++) 
            {
                KLineData currentKLdata = (KLineData)KLdata[i];
                KLineData lastKLdata = (KLineData)KLdata[i - RSI_NUM];
                last_data = lastKLdata.EndPrice - lastKLdata.StartPrice;
                if (last_data > 0)
                {
                    totalUP = totalUP - last_data;
                }
                else 
                {
                    totalDOWN = totalDOWN + last_data;
                }
                if (currentKLdata.StartPrice > currentKLdata.EndPrice)
                {
                    totalDOWN = totalDOWN + (currentKLdata.StartPrice - currentKLdata.EndPrice);
                }
                else
                {
                    totalUP = totalUP + (currentKLdata.EndPrice - currentKLdata.StartPrice);
                }
                tmp_rsi = (totalUP / RSI_NUM) * 100 / ((totalUP / RSI_NUM) + (totalDOWN / RSI_NUM));
                RSI.Add(new RSI_struct(tmp_UP, tmp_down, tmp_rsi));
            }

        }
        public void calculate() //計算買賣點
        {
            bool situationBuy = false;
            bool situationSell = false;
            for (int i = 0; i < RSI.Count; i++) 
            {

                if(situationBuy == false) 
                {
                    if (RSI[i].RSI > 70)
                    {
                        sellPoint.Add(i);
                        situationBuy = true;
                        situationSell = false;
                    }
                }
                if (situationSell == false) 
                {
                    if (RSI[i].RSI < 30 & RSI[i].RSI > 0)
                    {
                        buyPoint.Add(i);
                        situationSell = true;
                        situationBuy = false;
                    }
                }
            }
        }

        public override void Draw(out List<int> BuyPoint, out List<int> SellPoint, out List<KLineData> Kldata)
        {
            BuyPoint = buyPoint;
            SellPoint = sellPoint;
            Kldata = KLdata;
        }
        public void draw() //標記買賣點位置
        {
            calculate();
            DrawData();
        }
    }
}
