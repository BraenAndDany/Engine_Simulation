using System;
using System.Reflection;
using Engine;
using static Engine.Engine;

namespace Engine_Simulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the ambient temperature");
            Enternal_Combustion_Engine engine_stats =new Enternal_Combustion_Engine();
            double Ambient_Temperature=Convert.ToDouble(Console.ReadLine());
            //инициализация переменных для манипуляции с ними
            double boost_M, boost_V, Rotational_Moment = engine_stats.Rotational_Moment[0], Crankshaft_Rotation_Speed = engine_stats.Crankshaft_Rotation_Speed[0], Dependency_Ratio_Hm=engine_stats.Dependency_Ratio_Hm, Dependency_Ratio_Hv=engine_stats.Dependency_Ratio_Hv, Dependency_Ratio_C=engine_stats.Dependency_Ratio_C;
            int seconds = 0, array_counter_M=1 ,array_counter_V = 0;
            double Engine_Temperature = Ambient_Temperature;
            double Engine_Heating,Engine_Cooling,Hm, Hv,Engine_Power;
            //цикл который симулирует график приведённый в задании
            while (true)
            {
                if (engine_stats.Rotational_Moment[array_counter_M]<=Rotational_Moment)
                {
                    array_counter_M++;
                    array_counter_V++;
                }   
                boost_M = engine_stats.Rotational_Moment[array_counter_M]/engine_stats.Crankshaft_Rotation_Speed[array_counter_M];
                boost_V = engine_stats.Rotational_Moment[array_counter_V] / engine_stats.Engine_Inertia;
                Rotational_Moment = Rotational_Moment + boost_M;
                Crankshaft_Rotation_Speed = Crankshaft_Rotation_Speed + boost_V;
                Engine_Heating = engine_stats.Engine_Heating_Speed(Rotational_Moment,Crankshaft_Rotation_Speed,Dependency_Ratio_Hm,Dependency_Ratio_Hv);
                Engine_Cooling = engine_stats.Engine_Cooling_Rate(Ambient_Temperature,Engine_Temperature,Dependency_Ratio_C);
                Hm = engine_stats.Hm(Rotational_Moment, Engine_Heating);
                Hv = engine_stats.Hm(Crankshaft_Rotation_Speed, Engine_Heating);
                Engine_Temperature = engine_stats.Engine_Temperature(Engine_Temperature,Engine_Heating,Engine_Cooling);
                Dependency_Ratio_C=engine_stats.C(Engine_Cooling,Ambient_Temperature,Engine_Temperature);
                Engine_Power = Rotational_Moment * Crankshaft_Rotation_Speed / 1000;
                seconds++;
                //Вывод результатов при достижении максимально допустимой температуры
                if(Engine_Temperature>=engine_stats.Overheating_Temperature)
                {
                    Console.WriteLine("Time to overheating:"+ seconds+"sec");
                    Console.WriteLine("Maximum power:"+Engine_Power+ "kW");
                    Console.WriteLine("The speed of rotation of the crankshaft at this moment:"+Crankshaft_Rotation_Speed+ "radians/sec");
                    break;
                }
            }
        }
    }
}
