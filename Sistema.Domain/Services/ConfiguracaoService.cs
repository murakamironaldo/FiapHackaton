using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flunt.Notifications;
using Sistema.Domain.Entities;
using Sistema.Domain.Interfaces.Repositories;
using Sistema.Domain.Interfaces.Services;

namespace Sistema.Domain.Services
{
    public  class ConfiguracaoService:Notifiable<Notification>,IConfiguracaoService
    {
        public readonly IConfiguracaoRepository _configuracaoRepository;

        public ConfiguracaoService(IConfiguracaoRepository usuarioRepository)
        {
            _configuracaoRepository = usuarioRepository;
        }
        
        public IEnumerable<Configuracao> Listar()
        {
            return _configuracaoRepository.ListarTodos();
        }

        public Configuracao? Carregar(Guid id)
        {
            var obj = _configuracaoRepository.ListarWhere(m => m.Id == id).FirstOrDefault();
            if (obj == null)
            {
                AddNotification(new Notification("Configuracao", "Configuração não encontrada."));
            }
            return obj;

        }

        public IEnumerable<Configuracao> Listar(string grupoVariaveis)
        {
            var lista = _configuracaoRepository.Get(m => m.Variavel.Contains(grupoVariaveis));
            return lista;
        }

        public void Alterar(Guid id, string valor)
        {
            var obj = Carregar(id);
            if (obj != null)
            {
                obj.AlterarValor(valor);
                _configuracaoRepository.Alterar(obj);
            }
            else
            {
                AddNotification(new Notification("Configuracao", "Configuração não encontrada."));
            }
        }
    }
}
