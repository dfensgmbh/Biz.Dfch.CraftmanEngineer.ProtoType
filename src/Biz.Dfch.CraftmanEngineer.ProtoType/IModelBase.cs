namespace Biz.Dfch.CraftmanEngineer.ProtoType
{
    public interface IModelBase
    {
        IModelAction Initialise { get; }
        IModelAction Decommission { get; }
    }
}
