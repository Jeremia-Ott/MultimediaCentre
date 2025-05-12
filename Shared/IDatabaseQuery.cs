namespace Shared;

public interface IDatabaseQuery
{
    Task CreateMedia();
    Task ReadOneMedia();
    Task ReadAllMedia();
    Task UpdateMedia();
    Task DeleteMedia();
    Task CreateRelation();
    Task ReadRelationById();
    Task ReadFamileTree();
    Task DeleteRelation();
}
