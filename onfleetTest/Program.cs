using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using onfleet;

namespace onfleetTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ofTeamService ts = new ofTeamService("37bef89ed1014c9a6dd60956a17fa996");
            var teams = ts.List();
            var teamIds = new List<string>();
            foreach (var item in teams)
            {
                Console.WriteLine(item.Name + " - " + item.Id);
                teamIds.Add(item.Id);
            }

            ofTaskService taskService = new ofTaskService("37bef89ed1014c9a6dd60956a17fa996");
            var tasks = taskService.List();
            //var teamIds = new List<string>();
            foreach (var item in tasks)
            {
                Console.WriteLine(item.State + " - " + item.Id);
                //teamIds.Add(item.Id);
            }
            Console.WriteLine(" ========Destinations======= " );
            ofDestinationService ds = new ofDestinationService("37bef89ed1014c9a6dd60956a17fa996");
            var destinationCreateOptions = new ofDestinationCreateOptions
            {
                Location = null,
                Address = new ofAddress { Unparsed = "34 Larden Road, W3 7SU" }
            };
            var destination = ds.Create(destinationCreateOptions);
            var d2 = ds.Get(destination.Id);

            Console.WriteLine(d2.Id + " - " + d2.Address.PostalCode);
            
            var c = Console.ReadLine();
            //ofWorkerService ws = new ofWorkerService("37bef89ed1014c9a6dd60956a17fa996");
            //ofWorker worker = new ofWorker();
            //ofWorkerCreateOptions createOptions = new ofWorkerCreateOptions();
            //createOptions.Name = "Ahmed";
            //createOptions.Phone = "+447445544401";
            //createOptions.Vehicle = new ofVehicleCreateOptions { VehicleType = VehicleTypes.Motorcycle, Color = "Red", LicensePlate = "LL04HSX" };
            //createOptions.Teams = teamIds;

            //worker = ws.Create(createOptions);

        }
    }
}
