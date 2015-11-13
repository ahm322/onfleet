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
            //ofTeamService ts = new ofTeamService();
            
            //var teams = ts.List();
            //var teamIds = new List<string>();
            //Console.WriteLine(" ========Teams======= ");
            //foreach (var item in teams)
            //{
            //    Console.WriteLine(item.Name + " - " + item.Id);
            //    teamIds.Add(item.Id);
            //}

           ofTaskService taskService = new ofTaskService();
            //var tasks = taskService.List();
            //Console.WriteLine(" ========Tasks======= ");
            //foreach (var item in tasks)
            //{
            //    Console.WriteLine(item.State + " - " + item.Id);
            //    //teamIds.Add(item.Id);
            //}
            //Console.WriteLine(" ========New Destination======= ");
            //ofDestinationService ds = new ofDestinationService();
            //var destinationCreateOptions = new ofDestinationCreateOptions
            //{
            //    Location = null,
            //    Address = new ofAddress { Unparsed = "12 cumberland ave, NW10 7QL" }
            //};
            //var destination = ds.Create(destinationCreateOptions);
            //var d2 = ds.Get(destination.Id);
            //Console.WriteLine(d2.Id + " - " + d2.Address.PostalCode);

            //var reService = new ofRecipientService();
            //var rec = reService.FindByPhone("07445544401");


            var orgService = new ofOrgnizationService();
            var org = orgService.Get();

            ofTaskCreateOptions taskCreateOptions = new ofTaskCreateOptions
            {
                Merchant = org.Id,
                Executor = org.Id,
                //DestinationId = d2.Id,
                //Recipients = new List<string> { rec.Id }
            };

            //var task = taskService.Create(taskCreateOptions);
            //Console.WriteLine(" New task created: " + task.Id);

            
            ofWorkerService ws = new ofWorkerService();
            //ofWorker worker = new ofWorker();
            //ofWorkerCreateOptions createOptions = new ofWorkerCreateOptions();
            //createOptions.Name = "Ahmed";
            //createOptions.Phone = "+447445544401";
            //createOptions.Vehicle = new ofVehicleCreateOptions { VehicleType = VehicleTypes.Motorcycle, Color = "Red", LicensePlate = "LL04HSX" };
            //createOptions.Teams = teamIds;
            //try
            //{
            //    worker = ws.Create(createOptions);
            //}
            //catch (ofException exception)
            //{
            //    Console.WriteLine(" Error: " + exception.Error.Message.Message);
            //}

            //ofWorkerUpdateOptions updateOptions = new ofWorkerUpdateOptions();
            //updateOptions.Tasks = new List<string> { task.Id };
            //ws.Update(worker.Id, updateOptions);

            var workers = ws.List();
            foreach (var item in workers)
            {
                Console.WriteLine(string.Format("name: {0} - id: {1}", item.Name, item.Id));
            }
            var c = Console.ReadLine();

            //ofRequestOptions opt = new ofRequestOptions { ApiKey =  };

            taskService.CreateWithDestinationAndWorker(taskCreateOptions,"34 Larden Road, W37SU", c);
            
        }
    }
}
