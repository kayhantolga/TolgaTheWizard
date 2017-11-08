using System.Linq;

namespace TolgaTheWizard.Extensions
{
    public static class ObjectMappingExtensions
    {
        /// <summary>
        /// Tyhis method can be usefull if you want to get base class from derived class 
        /// </summary>
        /// <typeparam name="TU">Type of the target class</typeparam>
        /// <param name="source">Source class</param>
        /// <returns></returns>
        public static TU To<TU>(this object source) where TU : new()
        {
            var target = new TU();
            var sourceProps = source.GetType().GetProperties();

            sourceProps.ToList().ForEach(prop =>
            {
                var targetProp = target.GetType().GetProperty(prop.Name);
                if (targetProp != null)
                {
                    var value =prop.GetValue(source);
                    target.GetType().GetProperty(prop.Name)?.SetValue(target, value, null);
                }
            });
            return target;
        }
    }
}
