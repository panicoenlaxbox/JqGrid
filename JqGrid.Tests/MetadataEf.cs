using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using JqGrid.Models.Entities;
using NUnit.Framework;

namespace JqGrid.Tests
{
    public class MetadataEf
    {
        [Test]
        public void Foo()
        {
            using (var context = new ShopContext(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DecisionPlatform-Development;Trusted_Connection=True;MultipleActiveResultSets=True;Application Name=DecisionPlatform-Development"))
            {

                ObjectContext objectContext = ((IObjectContextAdapter)context).ObjectContext;
                EntityContainer entityContainer =
                    objectContext.MetadataWorkspace.GetEntityContainer(objectContext.DefaultContainerName,
                        DataSpace.CSpace);
                foreach (EntitySetBase entitySetBase in entityContainer.BaseEntitySets)
                {
                    var entitySet = entitySetBase as EntitySet;
                    if (entitySet == null)
                    {
                        Debug.WriteLine(entitySetBase.GetType().Name); // AssociationSet
                        continue;
                    }
                    Debug.WriteLine($"Entity {entitySetBase.Name}");
                    foreach (EdmMember member in entitySet.ElementType.Members)
                    {
                        if (member is EdmProperty)
                        {
                            var property = member as EdmProperty;
                            string type = "";
                            bool isEnum = false;
                            bool nullable = property.Nullable;
                            if (property.IsPrimitiveType)
                            {
                                type = property.PrimitiveType.Name;
                            }
                            else if (property.IsEnumType)
                            {
                                isEnum = true;
                                var enumType = property.EnumType;
                                type = enumType.Name;
                            }
                            Debug.WriteLine($"\tProperty {property.Name} isEnum {isEnum} {type} nullable {nullable}");
                        }
                        else if (member is NavigationProperty)
                        {
                            var navigation = member as NavigationProperty;
                            Debug.WriteLine($"\tNavigation {navigation.Name}");
                        }
                    }
                }
            }
        }

        [Test]
        public void RuntimeTextTemplate()
        {
            //var template = new HelpMessage
            //{
            //    Session = new Dictionary<string, object> { { "sender", "sergio" }, { "receiver", "Help Desk" } }
            //};
            //template.Initialize();
            //Console.WriteLine(template.TransformText());
        }
    }
}