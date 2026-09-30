using RobotFactorySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotFactorySystem
{
    public abstract class RobotPrototype
    {
        public string modelName;
        public int batteryCapacity; 
        public string softwareVersion;

        public RobotPrototype(string modelName, int batteryCapacity, string softwareVersion)
        {
            this.modelName = modelName;
            this.batteryCapacity = batteryCapacity;
            this.softwareVersion = softwareVersion;
        }

        public abstract RobotPrototype Clone();
        public abstract void DisplayDetails();
    }

    // Concrete Prototype: Service Robot
    public class ServiceRobot : RobotPrototype
    {
        public string serviceTask;

        public ServiceRobot(string modelName, int batteryCapacity, string softwareVersion, string serviceTask)
            : base(modelName, batteryCapacity, softwareVersion)
        {
            this.serviceTask = serviceTask;
        }

        public override RobotPrototype Clone()
        {
            return new ServiceRobot(this.modelName, this.batteryCapacity, this.softwareVersion, this.serviceTask);
        }

        public override void DisplayDetails()
        {
            Console.WriteLine($"[Service Robot] Model: {modelName} | Battery: {batteryCapacity}h | Software: {softwareVersion} | Task: {serviceTask}");
        }
}
    public class IndustrialRobot : RobotPrototype
{
    public string industrialTask;

    public IndustrialRobot(string modelName, int batteryCapacity, string softwareVersion, string industrialTask)
        : base(modelName, batteryCapacity, softwareVersion)
    {
        this.industrialTask = industrialTask;
    }

    public override RobotPrototype Clone()
    {
        return new IndustrialRobot(this.modelName, this.batteryCapacity, this.softwareVersion, this.industrialTask);
    }

    public override void DisplayDetails()
    {
        Console.WriteLine($"[Industrial Robot] Model: {modelName} | Battery: {batteryCapacity}h | Software: {softwareVersion} | Task: {industrialTask}");
    }
}

// Concrete Prototype: Entertainment Robot
public class EntertainmentRobot : RobotPrototype
{
    public string entertainmentFeature;

    public EntertainmentRobot(string modelName, int batteryCapacity, string softwareVersion, string entertainmentFeature)
        : base(modelName, batteryCapacity, softwareVersion)
    {
        this.entertainmentFeature = entertainmentFeature;
    }

    public override RobotPrototype Clone()
    {
        return new EntertainmentRobot(this.modelName, this.batteryCapacity, this.softwareVersion, this.entertainmentFeature);
    }

    public override void DisplayDetails()
    {
        Console.WriteLine($"[Entertainment Robot] Model: {modelName} | Battery: {batteryCapacity}h | Software: {softwareVersion} | Feature: {entertainmentFeature}");
    }
}
    // Client Code
    class Program
    {
        static void Main(string[] args)
        {
            ServiceRobot healthcareProto = new ServiceRobot("CareBot-X", 12, "v1.0", "Healthcare Assistance");
            IndustrialRobot assemblyProto = new IndustrialRobot("RoboArm-3000", 24, "v2.1", "Automated Welding");

            Console.WriteLine("--- Original Prototypes ---");
            healthcareProto.DisplayDetails();
            assemblyProto.DisplayDetails();

            Console.WriteLine("\n--- Cloned & Customized Robots ---");

            // Customer Order 1: Healthcare Robot with upgraded battery and updated software
            ServiceRobot customizedCareBot = (ServiceRobot)healthcareProto.Clone();
            customizedCareBot.batteryCapacity = 18;
            customizedCareBot.softwareVersion = "v1.2";
            customizedCareBot.DisplayDetails();

            // Customer Order 2: Industrial Robot with software update
            IndustrialRobot customizedArm = (IndustrialRobot)assemblyProto.Clone();
            customizedArm.softwareVersion = "v2.5";
            customizedArm.DisplayDetails();
        }
    }
}