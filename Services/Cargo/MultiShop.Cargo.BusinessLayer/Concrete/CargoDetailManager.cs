using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CargoDetailManager : ICargoDetailService
    {
        private readonly ICargoDetailDal cargoDetail;
        public CargoDetailManager(ICargoDetailDal cargoDetail)
        {
            this.cargoDetail = cargoDetail;
        }

        public void TDelete(int id)
        {
            cargoDetail.Delete(id);
        }

        public IEnumerable<CargoDetail> TGetAll()
        {
            return cargoDetail.GetAll();
        }

        public CargoDetail TGetById(int id)
        {
            return cargoDetail.GetById(id);
        }

        public void TInsert(CargoDetail entity)
        {
            cargoDetail.Insert(entity);
        }

        public void TUpdate(CargoDetail entity)
        {
            cargoDetail.Update(entity);
        }
    }
}
