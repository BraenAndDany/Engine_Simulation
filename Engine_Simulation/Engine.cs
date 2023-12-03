using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    internal class Engine
    { 
        //класс Engine получил класс отвечающий за двигатель внутреннего сгорания(ДВС), в Engine можно добавлять новые типы двигателей
        public class Enternal_Combustion_Engine : Engine
        {
            //сдесь сохранены все уже заранее заданные значения
            public int Engine_Inertia = 10;
            public double[] Rotational_Moment = {20,75,100,105,75,0};
            public double[] Crankshaft_Rotation_Speed = {0,75,150,200,250,300};
            public int Overheating_Temperature = 110;
            public double Dependency_Ratio_Hm = 0.01;
            public double Dependency_Ratio_Hv = 0.0001;
            public double Dependency_Ratio_C = 0.1;
            //далее идут методы для формул
            public double Engine_Heating_Speed(double Rotational_Moment,double Crankshaft_Rotation_Speed, double Dependency_Ratio_Hm, double Dependency_Ratio_Hv)
            {
                double Heating_Speed = (Rotational_Moment * Dependency_Ratio_Hm) + (Math.Pow(Crankshaft_Rotation_Speed,2) * Dependency_Ratio_Hv);
                return Heating_Speed;
            }
            public double Engine_Cooling_Rate(double Ambient_Temperature,double Engine_Temperature,double Dependency_Ratio_C,double second)
            {
                double Cooling_Rate = Dependency_Ratio_C*(Ambient_Temperature-Engine_Temperature/3.56);
                return Cooling_Rate;
            }
            public double Engine_Power(double Rotational_Moment, double Crankshaft_Rotation_Speed)
            {
                double engine_power = Rotational_Moment * Crankshaft_Rotation_Speed / 1000;
                return engine_power;
            }
            public double Engine_Temperature(double Engine_Temperature, double Engine_Heating, double Engine_Cooling, double Ambient_Temperature,double second)
            {
                Engine_Temperature=Ambient_Temperature+(Engine_Heating+Engine_Cooling)*second;
                return Engine_Temperature;
            }
            public double C(double Engine_Temperature, double Ambient_Temperature, double Engine_Cooling_Rate)
            {
                double C = Engine_Cooling_Rate / (Ambient_Temperature - Engine_Temperature);
                return C;
            }
        }

    }
}
