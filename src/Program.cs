using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    /// <summary>
    /// Класс для расчёта скидок в системе заказов компании «ТехноМир»
    /// (продажа электроники).
    /// </summary>
    public class DiscountCalculator
    {
        /// <summary>
        /// Размер скидки для товаров, по которым не было заказов
        /// в прошлом месяце (20%).
        /// </summary>
        public const decimal DiscountRate = 0.20m;

        /// <summary>
        /// Рассчитывает цену со скидкой 20%, если по товару
        /// не было заказов в прошлом месяце.
        /// </summary>
        /// <param name="basePrice">Базовая цена товара.</param>
        /// <param name="hasOrdersLastMonth">Были ли заказы в прошлом месяце.</param>
        /// <returns>Цена со скидкой или базовая цена.</returns>
        public decimal GetDiscountedPrice(decimal basePrice, bool hasOrdersLastMonth)
        {
            if (hasOrdersLastMonth)
                return basePrice;

            return basePrice * (1m - DiscountRate);
        }

        /// <summary>
        /// Проверяет корректность базовой цены товара.
        /// </summary>
        /// <param name="basePrice">Проверяемая цена.</param>
        /// <returns>true, если цена неотрицательна; иначе false.</returns>
        public bool IsValidPrice(decimal basePrice)
        {
            return basePrice >= 0m;
        }
    }

    /// <summary>
    /// Точка входа программы: демонстрация расчёта скидки
    /// в системе заказов компании «ТехноМир».
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Запускает демонстрационный расчёт и выводит результат в консоль.
        /// </summary>
        /// <param name="args">Аргументы командной строки (не используются).</param>
        static void Main(string[] args)
        {
            var calculator = new DiscountCalculator();

            decimal price = 1000m;
            decimal discounted = calculator.GetDiscountedPrice(price, false);

            Console.WriteLine("Компания «ТехноМир» — продажа электроники");
            Console.WriteLine($"Базовая цена: {price}");
            Console.WriteLine($"Цена со скидкой 20%: {discounted}");
            Console.WriteLine($"Цена корректна: {calculator.IsValidPrice(price)}");
            Console.WriteLine("Белоногова Алиса, Группа И-42");

            Console.ReadKey();
        }
    }
}