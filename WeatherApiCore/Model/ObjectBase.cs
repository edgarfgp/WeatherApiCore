using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApiCore.Extensions;

namespace WeatherApiCore.Model
{
    /// <summary>
    /// Abstract entity that holds the information which is common between all the entities.
    /// </summary>
    public abstract class ObjectBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ObjectBase()
        {
            //Id = Guid.NewGuid();
            Class = this.GetType().Name;
        }

        /// <summary>
        /// Id of the object
        /// </summary>
        [JsonProperty("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Type of the object
        /// </summary>
        [JsonProperty("class")]
        public string Class { get; set; }

        /// <summary>
        /// Checks if the minimum data for the object is set.
        /// </summary>
        /// <returns>true if the object honors the Entity Integrity rules. </returns>
        public virtual bool IntegrityCheck()
        {
            return true;
        }

        /// <summary>
        /// Override of <see cref="object.Equals(object)"/>
        /// </summary>
        /// <param name="obj">Object comparing with.</param>
        /// <returns>true if both objects are Equal.</returns>
        public override bool Equals(object obj)
        {
            var o = obj as ObjectBase;

            if (o.IsNull())
                return base.Equals(obj);
            else
                return Id.Equals(o.Id) && Class.Equals(o.Class);
        }

        /// <summary>
        /// Override of the <see cref="object.GetHashCode"/> of the object.
        /// </summary>
        /// <returns>Hash of the object.</returns>        
        /// <remarks>
        /// <para>We are using this override to allow calling <see cref="System.Linq.Enumerable.Distinct{TSource}(IEnumerable{TSource})"/> function for this entity."/></para>
        /// <para>The GetHashCode() method should reflect the Equals logic; the rules are:        
        /// <list class="bullet">
        /// <listItem><para>if two things are equal(Equals(...) == true) then they must return the same value for GetHashCode().</para></listItem>
        /// <listItem><para>if the GetHashCode() is equal, it is not necessary for them to be the same; this is a collision, and Equals will be called to see if it is a real equality or not.</para></listItem>
        /// <listItem><para>the hash code should not change during the lifetime of an object. Therefore the fields which are used to calculate the hash code must be immutable.</para></listItem>
        /// </list>
        /// </para>
        /// </remarks>
        public override int GetHashCode()
        {
            return Class.GetHashCode();
        }
    }
}
