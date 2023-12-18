using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    internal class Program
    {
        static void Main(string[] args)
        {


            List<Transport> transports = new List<Transport>();
            transports.Add(new Cars { Model = "Audi", Color = "Color", IsRented = true, Categoryofrights = "B", Motor = "600 horsepower", NumberofWheels = 4, Speed = 300 });
            transports.Add(new Ships { Model = " Nor-Tech 5000", Color = "Fire", IsRented = true, Categoryofrights = "GIMS certificate", Motor = "3000 horsepower", NumberofWheels = 0, Speed = 170 });
            transports.Add(new Bikes { Model = "Merida", Color = "white", IsRented = false, Categoryofrights = "not required", Motor = "0.3 horsepower", NumberofWheels = 2, Speed = 30 });
            transports.Add(new Moto { Model = "Kawasaki Ninja H2R", Color = "Gray", IsRented = true, Categoryofrights = "A", Motor = "300 horsepower", NumberofWheels = 2, Speed = 400 });
            transports.Add(new Scooter { Model = "Xiomi", Color = "Color", IsRented = true, Categoryofrights = "not required", Motor = "not found", NumberofWheels = 2, Speed = 25 });
            Console.WriteLine("List of transports");
            foreach (Transport transport in transports)
            {
                transport.DisplayInfo();

            }
        }
    }
    abstract class Transport

    {
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Model: {Model}, Color: {Color}, Is Rented: {IsRented}, Categoryofrights{Categoryofrights},Motor{Motor}, NumberofWheels {NumberofWheels} , Speed {Speed}");
        }
        public Transport(string Model, string Color, bool IsRented, string Categoryofrights, string Motor, int NumberofWheels, int Speed)
        {
            this.Model = Model;
            this.Color = Color;
            this.IsRented = IsRented;
            this.Categoryofrights = Categoryofrights;
            this.Motor = Motor;
            this.Speed = Speed;
            this.NumberofWheels = NumberofWheels;
        }
        public string Model { get; set; }
        public string Color { get; set; }
        public bool IsRented { get; set; }
        public string Categoryofrights { get; set; }
        public string Motor { get; set; }
        public abstract void Move();
        public abstract int NumberofWheels { get; set; }
        public virtual void Bip()
        {
            Console.WriteLine("Bip");
        }
        int speed = 1;
        public virtual int Speed
        {
            get => Speed;
            set { if (value > 0 && value < 110) speed = value; }
        }
    }




    class Cars : Transport
    {
        public Cars(string Model = "Audi", string Color = "Color", bool IsRented = true, string Categoryofrights = "B", string Motor = "600 horsepower", int NumberofWheels = 4, int Speed = 300) : base(Model, Color, IsRented, Categoryofrights, Motor, NumberofWheels, Speed) { }

        public override void Move()
        {
            Console.WriteLine("Car rides");
        }
        public override int NumberofWheels
        {
            get => NumberofWheels;
            set { if (value > 0 && value < 4) NumberofWheels = value; }
        }
        public override void Bip()
        {
            Console.WriteLine("Bip");
        }
        public override int Speed
        {
            get => base.Speed;
            set { if (value > 0 && value < 300) base.Speed = value; }
        }
    }

    class Ships : Transport
    {
        public Ships(string Model = " Nor-Tech 5000", string Color = "Fire", bool IsRented = true, string Categoryofrights = "GIMS certificate", string Motor = "3000 horsepower", int NumberofWheels = 0, int Speed = 170) : base(Model, Color, IsRented, Categoryofrights, Motor, NumberofWheels, Speed) { }
        public override void Move()
        {
            Console.WriteLine("The ship is sailing");
        }
        public override void Bip()
        {
            Console.WriteLine("UUooooppp");
        }
        public override int Speed
        {
            get => base.Speed;
            set { if (value > 0 && value < 170) base.Speed = value; }
        }
        public override int NumberofWheels
        {
            get => NumberofWheels;
            set { if (value > 0 && value < 4) NumberofWheels = value; }
        }
    }
    class Bikes : Transport
    {
        public Bikes(string Model = "Merida", string Color = "white", bool IsRented = false, string Categoryofrights = "not required", string Motor = "0.3 horsepower", int NumberofWheels = 2, int Speed = 30) : base(Model, Color, IsRented, Categoryofrights, Motor, NumberofWheels, Speed) { }


        public override void Move()
        {
            Console.WriteLine("The bike is riding");
        }
        public override void Bip()
        {
            Console.WriteLine("dzdz");
        }
        public override int Speed
        {
            get => base.Speed;
            set { if (value > 0 && value < 30) base.Speed = value; }
        }

        public override int NumberofWheels
        {
            get => NumberofWheels;
            set { if (value > 0 && value < 4) NumberofWheels = value; }
        }
    }

    class Moto : Transport

    {
        public Moto(string Model = "Kawasaki Ninja H2R", string Color = "Gray", bool IsRented = true, string Categoryofrights = "A", string Motor = "300 horsepower", int NumberofWheels = 2, int Speed = 400) : base(Model, Color, IsRented, Categoryofrights, Motor, NumberofWheels, Speed) { }
        public override void Move()
        {
            Console.WriteLine("The motorcycle rides on target ");
        }
        public override void Bip()
        {
            Console.WriteLine("dzdz");
        }
        public override int Speed
        {
            get => base.Speed;
            set { if (value > 17 && value < 110) base.Speed = value; }
        }
        public override int NumberofWheels
        {
            get => NumberofWheels;
            set { if (value > 0 && value < 4) NumberofWheels = value; }
        }


    }
    class Scooter : Transport
    {
        public Scooter(string Model = "Xiomi", string Color = "Color", bool IsRented = true, string Categoryofrights = "not required", string Motor = "not found", int NumberofWheels = 2, int Speed = 25) : base(Model, Color, IsRented, Categoryofrights, Motor, NumberofWheels, Speed) { }
        public override void Move()
        {
            Console.WriteLine("The scooter is moving");
        }
        public override void Bip()
        {
            Console.WriteLine("dzdzing");
        }
        public override int NumberofWheels
        {
            get => NumberofWheels;
            set { if (value > 0 && value < 4) NumberofWheels = value; }
        }
        public override int Speed
        {
            get => base.Speed;
            set { if (value > 17 && value < 110) base.Speed = value; }
        }
    }
}
