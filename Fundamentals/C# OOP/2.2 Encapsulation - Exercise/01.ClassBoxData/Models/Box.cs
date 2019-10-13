namespace _01.ClassBoxData.Models
{
    using System;
    using System.Text;

    public class Box
    {
        private double length;
        public double width;
        public double height;

        public Box(double lenght, double width, double height)
        {
            this.Length = lenght;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                Validate(value, nameof(Length));
                this.length = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                Validate(value, nameof(Width));

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                Validate(value, nameof(Height));
                this.height = value;
            }
        }
        private static void Validate(double value, string name)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{name} cannot be zero or negative.");
            }
        }

        public double GetSurfaceArea()
        {
            return (2 * length * width) + GetLateralSurfaceArea();
        }

        public double GetLateralSurfaceArea()
        {
            return 2 * length * height + 2 * width * height;
        }

        public double GetVolume()
        {
            return length * width * height;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Surface Area - {this.GetSurfaceArea():F2}");
            sb.AppendLine($"Lateral Surface Area - {this.GetLateralSurfaceArea():F2}");
            sb.AppendLine($"Volume - {this.GetVolume():F2}");
            return sb.ToString().TrimEnd();
        }
    }
}
