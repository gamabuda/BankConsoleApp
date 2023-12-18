using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport2._0
{
    internal interface Interface1
    {

        public delegate void MoveHandler(string msg);


        public interface ITransport
        {
            event MoveHandler MoveEvent;


            void Move();


            void Stop();


            int GetSpeed();


            void SetMaxSpeed(int maxSpeed);
        }


        class Ships : ITransport
        {
            private int _maxSpeed;
            private int _currentSpeed;

            public event MoveHandler? MoveEvent;

            public void Move()
            {

                _currentSpeed = _maxSpeed;
                MoveEvent?.Invoke("Car is moving at " + _currentSpeed + " km/h");
            }

            public void Stop()
            {
                _currentSpeed = 0;
                MoveEvent?.Invoke("Car has stopped");
            }

            public int GetSpeed()
            {
                return _currentSpeed;
            }

            public void SetMaxSpeed(int maxSpeed)
            {
                _maxSpeed = maxSpeed;
            }
        }

        class Bikes : ITransport
        {
            private int _maxSpeed;
            private int _currentSpeed;

            public event MoveHandler MoveEvent;

            public void Move()
            {
                _currentSpeed = _maxSpeed;
                MoveEvent?.Invoke("Car is moving at " + _currentSpeed + " km/h");
            }

            public void Stop()
            {
                _currentSpeed = 0;
                MoveEvent?.Invoke("Car has stopped");
            }

            public int GetSpeed()
            {
                return _currentSpeed;
            }

            public void SetMaxSpeed(int maxSpeed)
            {
                _maxSpeed = maxSpeed;
            }
        }

        class Moto : ITransport
        {
            private int _maxSpeed;
            private int _currentSpeed;

            public event MoveHandler MoveEvent;

            public void Move()
            {
                _currentSpeed = _maxSpeed;
                MoveEvent?.Invoke("Car is moving at " + _currentSpeed + " km/h");
            }

            public void Stop()
            {
                _currentSpeed = 0;
                MoveEvent?.Invoke("Car has stopped");
            }

            public int GetSpeed()
            {
                return _currentSpeed;
            }

            public void SetMaxSpeed(int maxSpeed)
            {
                _maxSpeed = maxSpeed;
            }
        }

        class Scooter : ITransport
        {
            private int _maxSpeed;
            private int _currentSpeed;

            public event MoveHandler MoveEvent;

            public void Move()
            {
                _currentSpeed = _maxSpeed;
                MoveEvent?.Invoke("Car is moving at " + _currentSpeed + " km/h");
            }

            public void Stop()
            {
                _currentSpeed = 0;
                MoveEvent?.Invoke("Car has stopped");
            }

            public int GetSpeed()
            {
                return _currentSpeed;
            }

            public void SetMaxSpeed(int maxSpeed)
            {
                _maxSpeed = maxSpeed;
            }
        }

        class Program
        {
            public MoveHandler Move { get; private set; }

            public void Main()
            {
                Ships ship = new Ships();
                ship.MoveEvent += Move;
                ship.Move();

                Bikes bike = new Bikes();
                bike.MoveEvent += Move;
                bike.Move();

                Moto moto = new Moto();
                moto.MoveEvent += Move;
                moto.Move();

                Scooter scooter = new Scooter();
                scooter.MoveEvent += Move;
                scooter.Move();
            }

            static void OnMove()
            {
                Console.WriteLine("The transport is moving");
            }
        }
    }
}
