﻿using System;
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

            ofTaskService taskService = new ofTaskService("37bef89ed1014c9a6dd60956a17fa996");
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


            var orgService = new ofOrganizationService("37bef89ed1014c9a6dd60956a17fa996");
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


            ofWorkerService ws = new ofWorkerService("37bef89ed1014c9a6dd60956a17fa996");
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

            ofRecipientService recipientService = new ofRecipientService("37bef89ed1014c9a6dd60956a17fa996");


            //taskService.CreateWithDestinationAndWorker(taskCreateOptions,"34 Larden Road, W37SU", c);

            ofDestinationService destinationService = new ofDestinationService("37bef89ed1014c9a6dd60956a17fa996");

            var pickupAddress = destinationService.Create(new ofDestinationCreateOptions
            {
                Address = new ofAddress { Name = "Sand Flames", Number = "1", Street = "Victoria Road", City = "LONDON", PostalCode = "W3 6UN", Country = "United Kingdom" },
                Location = new double[] { -0.2604646, 51.5229645 }
            });
            //ofRecipientService recipientService = new ofRecipientService("37bef89ed1014c9a6dd60956a17fa996");
            var recipientPickup = recipientService.FindOrCreate("+442089932473", new ofRecipientsCreateOptions
            {
                Name = "Sand Flames",
                Phone = "+442089932473",
                SkipPhoneNumberValidation = true,
                SkipSMSNotifications = true
            });
            var recipientDelivery = recipientService.FindOrCreate("+447445544401", new ofRecipientsCreateOptions
            {
                Name = "Ahmed Abdulla",
                Phone = "+447445544401",
                SkipPhoneNumberValidation = true,
                SkipSMSNotifications = true
            });

            var deliveryAddress = destinationService.Create(new ofDestinationCreateOptions
            {
                Address = new ofAddress { Unparsed = "34 Larden Road, W3 7SU" }
            });



            ofTaskCreateOptions pickupCreateOptions = new ofTaskCreateOptions
            {
                Executor = org.Id,
                Merchant = org.Id,
                DestinationId = pickupAddress.Id,
                Recipients = new List<string> { recipientPickup.Id },
                Notes = "Order #2342",
                PickupTask = true
            };
            ofTaskCreateOptions deliveryCreateOptions = new ofTaskCreateOptions
            {
                Executor = org.Id,
                Merchant = org.Id,
                DestinationId = deliveryAddress.Id,
                Recipients = new List<string> { recipientDelivery.Id },
                Notes = "Order #2342",
                PickupTask = false
            };

            var task = taskService.CreatePickupAndDelivery(pickupCreateOptions, deliveryCreateOptions);
            Console.WriteLine("new task created: " + task.Id + " with pickup task: " + task.Dependencies.First());
            var c = Console.ReadLine();
            var worker = taskService.AssignToWorker(task.Id, workers.First().Id);
            var d = Console.ReadLine();
        }
    }
}
