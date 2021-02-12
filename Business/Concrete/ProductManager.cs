using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;

using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
     
    public class ProductManager : IProductService
    {
        IProductDal _poductDal ;

        public ProductManager(IProductDal productDal)
        {
            _poductDal = productDal;
        }

        public IResult Add(Product product)
        {
            //business codes
            if(product.ProductName.Length<2)
            {
                //magic string
                return new ErrorResult(Messages.ProductNameInvalid );
            }

            _poductDal.Add(product);
            return new SuccessResult(Messages.ProductAdded); //Result(true, "Ürün Eklendi");
        }

        public IDataResult<List<Product>> GetAll()
        {
            //İş kodları
            //Yetkisi var mı?
            if(DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>( _poductDal.GetAll(),Messages.ProductListed ) ;
        }

        public IDataResult< List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>( _poductDal.GetAll( p=>p.CategoryId ==id )) ;
        }

        public IDataResult< List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>( _poductDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max) ) ;
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>( _poductDal.Get(p => p.ProductId == productId) ) ; 
        }

        public IDataResult< List<ProductDetailDto>>  GetProductDetails()
        {
            return  new SuccessDataResult<List<ProductDetailDto>>( _poductDal.GetProductDetails() );
        }
    }
}

//bir issınıfı baska sınıfı new lemez