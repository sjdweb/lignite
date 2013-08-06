namespace Lignite.Controls
{
    public interface IUserControl
    {
        /// <summary>
        /// The Lignite control controller is the data path used for communication between controls and the parent form
        /// </summary>
        EventController Controller { get; set; }

        /// <summary>
        /// Gets the unique instance id for this object.
        /// </summary>
        /// <value>The unique instance ID.</value>
        string UniqueInstanceID { get; }
    }
}