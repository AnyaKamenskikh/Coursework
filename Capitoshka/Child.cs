//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Capitoshka
{
    using System;
    using System.Collections.Generic;
    
    public partial class Child
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Child()
        {
            this.ListGroups = new HashSet<ListGroups>();
        }
    
        public int ID { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public Nullable<int> IDParent { get; set; }
    
        public virtual Parents Parents { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ListGroups> ListGroups { get; set; }
    }
}
