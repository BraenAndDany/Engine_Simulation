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
            public double[] Crankshaft_Rotation_Speed = { 0, 75, 150, 200, 250, 300 };
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
            public double Engine_Cooling_Rate(double Ambient_Temperature,double Engine_Temperature,double Dependency_Ratio_C)
            {
                double Cooling_Rate = Dependency_Ratio_C*(Ambient_Temperature-Engine_Temperature);
                return Cooling_Rate;
            }
            public double Engine_Power(double Rotational_Moment, double Crankshaft_Rotation_Speed)
            {
                double engine_power = Rotational_Moment * Crankshaft_Rotation_Speed / 1000;
                return engine_power;
            }
            public double Engine_Temperature(double Engine_Temperature, double Engine_Heating, double Engine_Cooling)
            {
                Engine_Temperature=Engine_Temperature+Engine_Heating-Engine_Cooling;
                return Engine_Temperature;
            }
            public double Hm(double Rotational_Moment, double Engine_Heating)
            {
                double Hm = Rotational_Moment / Engine_Heating;
                return Hm;
            }
            public double Hv(double Crankshaft_Rotation_Speed, double Engine_Heating)
            {
                double Hv = Crankshaft_Rotation_Speed / Engine_Heating;
                return Hv;
            }
            public double C(double Engine_cooling, double Ambient_Temperature, double Engine_Temperature)
            {
              double C = Engine_cooling/(Ambient_Temperature-Engine_Temperature);
              return C;
            }
        }

    }
}
