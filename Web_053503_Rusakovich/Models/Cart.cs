﻿using System.Collections.Generic;
using System.Linq;
using Web_053503_Rusakovich.Entities;

namespace Web_053503_Rusakovich.Models
{
    public class Cart
    {
        public Dictionary<int, CartItem> Items { get; set; }
        public Cart()
        {
            Items = new Dictionary<int, CartItem>();
        }

        /// <summary>
        /// Количество объектов в корзине
        /// </summary>
        public int Count
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity);
            }
        }

        /// <summary>
        /// цена
        /// </summary>
        public int Price
        {
            get
            {
                return (int)Items.Sum(item => item.Value.Quantity * item.Value.Product.Price);
            }
        }

        /// <summary>
        /// Добавление в корзину
        /// </summary>
        /// <param name="product">добавляемый объект</param>
        public virtual void AddToCart(Product product)
        {
            // если объект есть в корзине
            // то увеличить количество
            if (Items.ContainsKey(product.Id))
                Items[product.Id].Quantity++;
            // иначе - добавить объект в корзину
            else
                Items.Add(product.Id, new CartItem
                {
                    Product = product,
                    Quantity = 1
                });
        }

        /// <summary>
        /// Удалить объект из корзины
        /// </summary>
        /// <param name="id">id удаляемого объекта</param>
        public virtual void RemoveFromCart(int id)
        {
            Items.Remove(id);
        }

        /// <summary>
        /// Очистить корзину
        /// </summary>
        public virtual void ClearAll()
        {
            Items.Clear();
        }
    }

    /// <summary>
    /// Клас описывает одну позицию в корзине
    /// </summary>
    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
