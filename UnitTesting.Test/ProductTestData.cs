using System;
using System.Collections;
using System.Collections.Generic;
using UnitTesting.Models;

namespace UnitTesting.Test
{
    public class ProductTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {GetPriceUnde50()};
            yield return new object[] {GetPriceOver50()};
        }

        private IEnumerable<Product> GetPriceUnde50()
        {
            decimal[] price = new decimal[] {275, 49.6m, 19.2m, 546.5m};
            for (int i = 0; i < price.Length; i++)
            {
                yield return new Product
                {
                    Name = $"P{i + 1}", Price = price[i]
                };
            }
        }

        private Product[] GetPriceOver50() => new Product[]
        {
            new Product {Name = "P1", Price = 5},
            new Product {Name = "P2", Price = 48.95M},
            new Product {Name = "P3", Price = 19.50M},
            new Product {Name = "P4", Price = 24.95M},
        };

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }    
}

