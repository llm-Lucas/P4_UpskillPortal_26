using System;

namespace PortalUpskill.App.Utils
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Calcula nova data somando um dado número de dias, sem contar com fins de semana
        /// </summary>
        /// <param name="date">A data de referência</param>
        /// <param name="daysToAdd">O número de dias a somar</param>
        public static DateTime AddWorkingDays(this DateTime date, int daysToAdd)
        {
            while (daysToAdd > 0)
            {
                date = date.AddDays(1);

                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                {
                    daysToAdd -= 1;
                }
            }

            return date;
        }

        /// <summary>
        /// Retorna o número de dias uteís entre as duas datas.
        /// </summary>
        /// <param name="start">Data Inicio</param>
        /// <param name="end">Data Fim</param>
        public static int WorkingDaysUntil(this DateTime start, DateTime end)
        {
            int totalWorkingDays = 0;
            while(start < end)
            {
                if(start.DayOfWeek != DayOfWeek.Saturday && start.DayOfWeek != DayOfWeek.Sunday)
                    totalWorkingDays++;
                start = start.AddDays(1);
            }

            return totalWorkingDays;
        }
    }
}
