using DreamsBytes.ECommerce.DTOs.Concrete.CartDtos;
using DreamsBytes.ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamsBytes.ECommerce.DataAccess.Interfaces
{
    public interface ICartDal : IGenericDal<Cart>
    {
        Cart GetByUserId(string userId);
        void DeleteFromCart(int cartId, int productId);
        void ClearCart(string cartId);
    }
}
