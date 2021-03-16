using System.Threading.Tasks;
using AutoMoq;
using Orchard.Domain;
using Orchard.Domain.Interfaces;
using Orchard.Domain.Services;
using Xunit;

namespace Orchard.Tests
{
    public class TreeServiceTest
    {
        [Fact]
        public void TreeService_RegisterNewTree_ShouldRegisterWithSucess()
        {
            var tree = new Tree();
            tree.Description = "Teste";
            tree.Age = 100;
            tree.SpecieId = 1;

            var mocker = new AutoMoqer();
            mocker.Create<Tree>();

            var treeService = mocker.Resolve<TreeService>();
            var repository = mocker.GetMock<ITreeRepository>();

            treeService.Add(tree);

            repository.Verify(r => r.Create(tree));
        }
  }
}