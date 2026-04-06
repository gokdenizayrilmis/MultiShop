using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CargoOperationManager : ICargoOperationService
    {
        private readonly ICargoOperationDal cargoOperationDal;

        public CargoOperationManager(ICargoOperationDal cargoOperationDal)
        {
            this.cargoOperationDal = cargoOperationDal;
        }

        public void TDelete(int id)
        {
            cargoOperationDal.Delete(id);
        }

        public IEnumerable<CargoOperation> TGetAll()
        {
            return cargoOperationDal.GetAll();
        }

        public CargoOperation TGetById(int id)
        {
            return cargoOperationDal.GetById(id);
        }

        public void TInsert(CargoOperation entity)
        {
            cargoOperationDal.Insert(entity);
        }

        public void TUpdate(CargoOperation entity)
        {
            cargoOperationDal.Update(entity);
        }
    }
}
