using biz.dfch.CS.Commons;

namespace Biz.Dfch.CraftmanEngineer.ProtoType
{
    public abstract class ModelActionBase : IModelAction
    {
        protected readonly ModelBase ModelBase;

        protected ModelActionBase(ModelBase modelBase)
        {
            ModelBase = modelBase;
        }

        public abstract DictionaryParameters Invoke(DictionaryParameters parameters);
    }
}