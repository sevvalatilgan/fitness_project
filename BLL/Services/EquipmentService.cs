using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public interface IEquipmentService
    {
        public IQueryable<EquipmentModel> Query();

        public ServiceBase Create(Equipment record);

        public ServiceBase Update(Equipment record);

        public ServiceBase Delete(int id);

    }
    public class EquipmentService : ServiceBase, IEquipmentService
    {
        public EquipmentService(Db db) : base(db) 
        {
        }

        public IQueryable<EquipmentModel> Query()
        {
            return _db.Equipments.OrderBy(e => e.Name).Select(e => new EquipmentModel() { Record = e });
        }

        public ServiceBase Create(Equipment record)
        {
            if (_db.Equipments.Any(e => e.Name.ToUpper() == record.Name.ToUpper().Trim()))
                return Error("Equipment with the same name exists!");

            record.Name = record.Name?.Trim();
            _db.Equipments.Add(record);
            _db.SaveChanges(); // Veritabanına işlemleri kaydet
            return Success("Equipment created successfully.");
        }

        public ServiceBase Delete(int id)
        {
            var entity = _db.Equipments.SingleOrDefault(e => e.Id == id);

            if (entity is null)
                return Error("Equipment can't be found!");

            _db.Equipments.Remove(entity);
            _db.SaveChanges(); // Veritabanına işlemleri kaydet
            return Success("Equipment deleted successfully.");
        
    }
        

        

        public ServiceBase Update(Equipment record)
        {
            if (_db.Equipments.Any(e => e.Id != record.Id && e.Name.ToUpper() == record.Name.ToUpper().Trim()))
                return Error("Equipment does not exists!");

            var entity = _db.Equipments.SingleOrDefault(e => e.Id == record.Id);
            if (entity is null)
                return Error("Equipment can't be found!");

            entity.Name = record.Name?.Trim();
            entity.TrainerId = record.TrainerId;

            _db.Equipments.Update(entity);
            _db.SaveChanges(); 
            return Success("Equipment updated successfully.");
        }
    }
}
