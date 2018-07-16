// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IViewModelMapper.cs" company="Centercom AB">
//     Centercom AB 2014-2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace FashionBoutik.Mappers
{
    public interface IViewModelMapper<in TFrom, out TTo>
    {
        TTo Map(TFrom model);
    }
}