using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskOne
{
    public enum TrafficLightColor
    {
        Red,
        Yellow,
        Green
    }

    public class TrafficLight
    {
        public const int MIN_DURATION = 100;

        private int rDuration = 1000;
        private int yDuration = 300;
        private int gDuration = 1000;

        private TrafficLightColor color = TrafficLightColor.Red;
        private int toNextDuration;

        private Timer timer = new Timer();

        public event EventHandler ChangeColor;

        public static TrafficLightColor GetNextColor(TrafficLightColor color) {
            return (TrafficLightColor) ((((int)color) + 1) % 3);
        }

        public TrafficLight(int rDuration, int yDuration, int gDuration, TrafficLightColor color): this()
        {
            this.rDuration = RDuration;
            this.yDuration = YDuration;
            this.gDuration = GDuration;
            this.color = Color;
        }

        public TrafficLight()
        {
            toNextDuration = rDuration;

            timer.Interval = 10;
            timer.Tick += (object sender, EventArgs e) => {
                toNextDuration -= timer.Interval;
                if (toNextDuration <= 0)
                {
                    color = GetNextColor(color);
                    toNextDuration =
                        color == TrafficLightColor.Red ? rDuration :
                            color == TrafficLightColor.Yellow ? yDuration : gDuration;
                    OnChangeColor(EventArgs.Empty);
                }
            };
            timer.Enabled = true;
        }

        protected virtual void OnChangeColor(EventArgs e)
        {
            if (ChangeColor != null)
                ChangeColor(this, e);
        }

        public int RDuration
        {
            get { return rDuration; }
            set { rDuration = Math.Max(value, MIN_DURATION); }
        }

        public int YDuration
        {
            get { return yDuration; }
            set { yDuration = Math.Max(value, MIN_DURATION); }
        }

        public int GDuration
        {
            get { return gDuration; }
            set { gDuration = Math.Max(value, MIN_DURATION); }
        }

        public TrafficLightColor Color
        {
            get { return color; }
            set
            {
                if (color != value)
                {
                    color = value; 
                    OnChangeColor(EventArgs.Empty);
                }
            }
        }
    }
}
