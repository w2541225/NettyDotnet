using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace IO.Netty.Util.Concurrent
{
    public class TimeUnit
    {
        public static readonly TimeUnit MILLISECONDS = new TimeUnit(MILLI_SCALE);
        public static readonly TimeUnit SECONDS = new TimeUnit(SECOND_SCALE);
        public static readonly TimeUnit MINUTES = new TimeUnit(MINUTE_SCALE);
        public static readonly TimeUnit HOURS = new TimeUnit(HOUR_SCALE);
        public static readonly TimeUnit DAYS = new TimeUnit(DAY_SCALE);


        public const int MILLI_SCALE = 1;
        public const int SECOND_SCALE = 1000 * MILLI_SCALE;
        public const int MINUTE_SCALE = 60 * SECOND_SCALE;
        public const int HOUR_SCALE = 60 * MINUTE_SCALE;
        public const int DAY_SCALE = 24 * HOUR_SCALE;

        private readonly int scale;
        private readonly int maxMillis;
        private readonly int maxSecs;
        private readonly int milliRatio;
        private readonly int secRatio;
        private readonly int unitScale;

        private TimeUnit(int unitScale)
        {
            var s = unitScale;
            this.scale = s;
            this.unitScale = unitScale;
            int mr = (s >= MILLI_SCALE) ? (s / MILLI_SCALE) : (MILLI_SCALE / s);
            this.milliRatio = (int)mr;
            this.maxMillis = int.MaxValue / mr;
            int sr = (s >= SECOND_SCALE) ? (s / SECOND_SCALE) : (SECOND_SCALE / s);
            this.secRatio = (int)sr;
            this.maxSecs = int.MaxValue / sr;
        }

        private static int Cvt(int d, int dst, int src)
        {
            int r, m;
            if (src == dst)
                return d;
            else if (src < dst)
                return d / (dst / src);
            else if (d > (m = int.MaxValue / (r = src / dst)))
                return int.MaxValue;
            else if (d < -m)
                return int.MaxValue;
            else
                return d * r;
        }

        public int convert(int sourceDuration, TimeUnit sourceUnit)
        {
            switch (this.unitScale)
            {
                case MILLI_SCALE: return sourceUnit.ToMillis(sourceDuration);
                case SECOND_SCALE: return sourceUnit.ToSeconds(sourceDuration);
                default: return Cvt(sourceDuration, scale, sourceUnit.scale);
            }
        }

        public int ToMillis(int duration)
        {
            int s, m;
            if ((s = scale) == MILLI_SCALE)
                return duration;
            else if (s < MILLI_SCALE)
                return duration / milliRatio;
            else if (duration > (m = maxMillis))
                return int.MaxValue;
            else if (duration < -m)
                return int.MinValue;
            else
                return duration * milliRatio;
        }

        public int ToSeconds(int duration)
        {
            int s, m;
            if ((s = scale) == SECOND_SCALE)
                return duration;
            else if (s < SECOND_SCALE)
                return duration / secRatio;
            else if (duration > (m = maxSecs))
                return int.MaxValue;
            else if (duration < -m)
                return int.MinValue;
            else
                return duration * secRatio;
        }

        public int ToMinutes(int duration)
        {
            return Cvt(duration, MINUTE_SCALE, scale);
        }

        public int toHours(int duration)
        {
            return Cvt(duration, HOUR_SCALE, scale);
        }

        public int ToDays(int duration)
        {
            return Cvt(duration, DAY_SCALE, scale);
        }



        public void TimedWait(Object obj, int timeout)

        {
            if (timeout > 0)
            {
                int ms = ToMillis(timeout);
                //obj.wait(ms, ns);
            }
        }


        public void TimedJoin(Thread thread, int timeout)
        {
            if (timeout > 0)
            {
                int ms = ToMillis(timeout);

                thread.Join(ms);
            }
        }

        public void Sleep(int timeout)
        {
            if (timeout > 0)
            {
                int ms = ToMillis(timeout);
                Thread.Sleep(ms);
            }
        }

    }


}
