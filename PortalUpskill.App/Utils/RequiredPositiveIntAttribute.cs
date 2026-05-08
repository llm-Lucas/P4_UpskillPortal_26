using System.ComponentModel.DataAnnotations;

namespace PortalUpskill.App.Utils
{
    /// <summary>
    /// Specifies that a data field value is required AND and a positive int
    /// </summary>
    public class RequiredPositiveIntAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null || (int)value <= 0)
			{
                return false;
			}
            else
			{
                return true;
			}
        }
    }
}
