using System;

public interface INterfejs
{
    void Log(string msg);
}

namespace kalkulator
{
    public class Class1
    {
        private INterfejs logger;

        public Class1()
        {
        }

        public Class1(INterfejs i)
        {
            this.logger = i;
        }
        
        public float Dodaj(float a, float b)
        {
            logger.Log("log");
            return a + b;
            
        }

        public double Mnoz(int i, int i1)
        {
            return i * i1;
        }

        public double Odejmij(int i, int i1)
        {
            return i - i1;
        }
    }
}