using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LABS_C_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int width = 7;
            int height = 7;
            Shape shape1 = new Triangle(width, height);
            textBox1.Text = shape1.CalculateSquere().ToString();

            Shape shape2 = new Rectangle(width, height);
            textBox2.Text = shape2.CalculateSquere().ToString();

            IShape shape3 = new Square();
            textBox3.Text = shape3.CalculateArea().ToString();
        }

    }

    public interface IShape
    {
        float CalculateArea();
    }

    public interface IWritible
    {
        void Write();
    }

    public class Square : IShape, IWritible
    {
        public float Side { get; set; }

        public Square(float side = 7)
        {
            Side = side;
        }

        public float CalculateArea()
        {
            return Side * Side;
        }

        public void Write()
        {
            Console.WriteLine("Square.");
        }
    }

    public abstract class Shape
    {
        protected float Width;
        protected float Height;

        public Shape(float width, float height)
        {
            Width = width;
            Height = height;
        }

        public abstract float CalculateSquere();
    }


    public class Triangle : Shape
    {
        public Triangle(float width, float height) : base(width, height) { }

        public override float CalculateSquere()
        {
            return 0.5f * Width * Height;
        }
    }

    public class Rectangle : Shape
    {
        public Rectangle(float width, float height) : base(width, height) { }

        public override float CalculateSquere()
        {
            return Height * Width;
        }
    }
}