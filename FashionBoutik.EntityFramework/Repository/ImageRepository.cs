using System;
using FashionBoutik.Data;
using FashionBoutik.Entities;

namespace FashionBoutik.EntityFramework.Repository
{
    public class ImageRepository : Repository<BinaryObject, long>, IImageRepository
    {
        public ImageRepository(AppDbContext context) :  base (context)
        {
        }
    }
}