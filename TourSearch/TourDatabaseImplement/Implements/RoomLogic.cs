using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using TourSearchBusinessLogic.BindingModels;
using TourSearchBusinessLogic.Interfaces;
using TourSearchBusinessLogic.ViewModel;
using TourSearchDatabaseImplement.Models;

namespace TourSearchDatabaseImplement.Implements
{
   public class RoomLogic : IRoomLogic
    {
        private readonly string RoomFileName = "D://TourData//Rooms.xml";
        public List<Room> Rooms { get; set; }
        public RoomLogic()
        {
            Rooms = LoadRooms();
        }
        public List<Room> LoadRooms()
        {
            var list = new List<Room>();
            if (File.Exists(RoomFileName))
            {
                XDocument xDocument = XDocument.Load(RoomFileName);
                var xElements = xDocument.Root.Elements("room").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Room
                    {
                        RoomId = Convert.ToInt32(elem.Attribute("id").Value),
                        RoomName = elem.Attribute("RoomName").Value,
                    });
                }
            }
            return list;
        }
        public void Database()
        {
            var rooms = LoadRooms();
            using (var context = new TourSearchDatabase())
            {
                foreach (var room in rooms)
                {
                    Room element = context.Rooms.FirstOrDefault(rec => rec.RoomId == room.RoomId);
                    if (element != null)
                    {
                        break;
                    }
                    else
                    {
                        element = new Room();
                        context.Rooms.Add(element);
                    }
                    element.RoomId = room.RoomId;
                    element.RoomName = room.RoomName;
                    context.SaveChanges();
                }
            }
        }
        public List<RoomViewModel> Read(RoomBindingModel model)
        {
            Database();
            return Rooms
            .Where(rec => model == null || rec.Id == model.Id)
            .Select(rec => new RoomViewModel
            {
                Id = rec.Id,
                RoomId = rec.RoomId,
                RoomName = rec.RoomName,
            })
            .ToList();
        }
    }
}
