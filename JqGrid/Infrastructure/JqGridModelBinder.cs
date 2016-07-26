using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace JqGrid.Infrastructure
{
    public class JqGridModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext,
            ModelBindingContext bindingContext)
        {
            var retval = new JqGrid
            {
                Rows = int.Parse(bindingContext.ValueProvider.GetValue("rows").AttemptedValue),
                Page = int.Parse(bindingContext.ValueProvider.GetValue("page").AttemptedValue)
            };
            var npage = bindingContext.ValueProvider.GetValue("npage");
            int npages;
            if (npage != null &&
                int.TryParse(bindingContext.ValueProvider.GetValue("npage").AttemptedValue, out npages))
            {
                retval.Pages = npages;
            }
            var sidx = bindingContext.ValueProvider.GetValue("sidx").AttemptedValue;
            var sord = bindingContext.ValueProvider.GetValue("sord").AttemptedValue;
            retval.Sort = new List<JqGridSort>();
            var values = sidx.Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries);
            if (values.Length == 1)
            {
                ((IList<JqGridSort>) retval.Sort).Add(new JqGridSort
                {
                    Sort = values[0],
                    Order = (JqGridOrder) Enum.Parse(typeof(JqGridOrder), sord, ignoreCase: true)
                });
            }
            else
            {
                for (var i = 0; i < values.Length; i++)
                {
                    var value = values[i].Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
                    var sort = new JqGridSort
                    {
                        Sort = value[0]
                    };
                    if (i == values.Length - 1)
                    {
                        sort.Order = (JqGridOrder) Enum.Parse(typeof(JqGridOrder), sord, ignoreCase: true);
                    }
                    else
                    {
                        sort.Order = (JqGridOrder) Enum.Parse(typeof(JqGridOrder), value[1], ignoreCase: true);
                    }
                    ((IList<JqGridSort>) retval.Sort).Add(sort);
                }
            }
            return retval;
        }
    }
}