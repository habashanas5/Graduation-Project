<<<<<<< HEAD
﻿using GraduationProject.Applications.Products;
using GraduationProject.DTOS;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.ApiOData
{
    public class ProductController : ODataController
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [EnableQuery]
        public IQueryable<ProductDto> Get()
        {
            return _productService
                .GetAll()
                .Include(x => x.ProductGroup)
                .Include(x => x.UnitMeasure)
                .Select(rec => new ProductDto
                {
                    Id = rec.Id,
                    Name = rec.Name,
                    Number = rec.Number,
                    RowGuid = rec.RowGuid,
                    CreatedAtUtc = rec.CreatedAtUtc,
                    ProductGroup = rec.ProductGroup!.Name,
                    UnitMeasure = rec.UnitMeasure!.Name,
                    UnitPrice = rec.UnitPrice,
                    Physical = rec.Physical,
                    rating = rec.rating,
                    oldPrice = rec.oldPrice,
                    MetaKeyWords = rec.MetaKeyWords,
                    RatingAverage = rec.RatingAverage,
                });
        }


    }
}
=======
﻿using GraduationProject.Applications.Products;
using GraduationProject.DTOS;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.ApiOData
{
    public class ProductController : ODataController
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [EnableQuery]
        public IQueryable<ProductDto> Get()
        {
            return _productService
                .GetAll()
                .Include(x => x.ProductGroup)
                .Include(x => x.UnitMeasure)
                .Select(rec => new ProductDto
                {
                    Id = rec.Id,
                    Name = rec.Name,
                    Number = rec.Number,
                    RowGuid = rec.RowGuid,
                    CreatedAtUtc = rec.CreatedAtUtc,
                    ProductGroup = rec.ProductGroup!.Name,
                    UnitMeasure = rec.UnitMeasure!.Name,
                    UnitPrice = rec.UnitPrice,
                    Physical = rec.Physical,
                    rating = rec.rating,
                    oldPrice = rec.oldPrice,
                    MetaKeyWords = rec.MetaKeyWords,
                    RatingAverage = rec.RatingAverage,
                });
        }


    }
}
>>>>>>> c44e5491702d5f390efd342c62b729fc7935292e
