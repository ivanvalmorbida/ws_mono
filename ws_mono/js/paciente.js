var app = angular.module("PacientesApp", ['angularSoap','ngMaterial', 'ui.mask']);

app.directive('uiCep', function(){
  return {
    require: 'ngModel',
    link: function(scope, element, attr, ctrl){
    var _formatCep = function(cep){
      cep = cep.replace(/[^0-9]+/g, "")        
      if(cep.length > 5){
        cep = cep.substring(0,5) + "-" + cep.substring(5,8)
      }
      return cep
    }
    element.bind('keyup', function(){
      ctrl.$setViewValue(_formatCep(ctrl.$viewValue))
      ctrl.$render()
    })
    }
  }
})

app.directive('uiTelefone', function(){
  return {
    require: 'ngModel',
    link: function(scope, element, attr, ctrl){
    var _formatTelefone = function(telefone){
      //(99)9999-9999 - 13dig
      //(99)99999-9999 - 14dig
      telefone = telefone.replace(/[^0-9]+/g, "")        
      if(telefone.length > 0){
        telefone = telefone.substring(-1,0) + "(" + telefone.substring(0)
      }
      if(telefone.length > 3){
        telefone = telefone.substring(0,3) + ")" + telefone.substring(3)
      }
      if(telefone.length == 12){
        telefone = telefone.substring(0,8) + "-" + telefone.substring(8)
      }else if(telefone.length >= 13){
        telefone = telefone.substring(0,9) + "-" + telefone.substring(9,13)
      }
      return telefone
    }
    element.bind('keyup', function(){
      ctrl.$setViewValue(_formatTelefone(ctrl.$viewValue))
      ctrl.$render()
    })
    }
  }
})

app.factory("PacienteService", ['$soap',function($soap){
	var base_url = "http://127.0.0.1:8080/paciente.asmx"

    var getPacienteCPF = function(){
            return $soap.post(base_url,"getPacienteCPF")
        }

    var getEstadoCivil = function(){
            return $soap.post(base_url,"getEstadoCivil")
        }

    var getProfissoes = function(){
            return $soap.post(base_url,"getProfissoes")
        }

    var getConvenio = function(){
            return $soap.post(base_url,"getConvenio")
        }

    var getBairro = function(){
            return $soap.post(base_url,"getBairro")
        }

    var getCEP = function(cep){
            return $soap.post(base_url,"getCEP", {strCep: cep})
        }

	return {
        getPacienteCPF:getPacienteCPF,
        getEstadoCivil: getEstadoCivil,
        getProfissoes: getProfissoes,
        getConvenio: getConvenio,
        getBairro: getBairro,
        getCEP: getCEP
    }
}])

app.controller("PacientesCtrl", function ($scope, $http, PacienteService) {
    PacienteService.getEstadoCivil().then(function(response){
        $scope.est_civ = JSON.parse(response)
    })

    PacienteService.getProfissoes().then(function(response){
        $scope.profi = JSON.parse(response)
    })

    PacienteService.getConvenio().then(function(response){
        $scope.conve = JSON.parse(response)
    })

    PacienteService.getBairro().then(function(response){
        $scope.bairr = JSON.parse(response)
    })

    $scope.BuscarCEP = function() {
        PacienteService.getCEP($scope.cep).then(function(response){
            cep = JSON.parse(response)[0]
            $scope.cidade = cep.Cidade
            $scope.uf = cep.UF
        })
    }

    PacienteService.getPacienteCPF().then(function(response){
        var paci = JSON.parse(response)

        if(paci.length!=0){
            var paci = paci[0]

            $scope.cpf = paci.CNPJCPF
            $scope.nome = paci.NOME
            $scope.nascimento = new Date(paci.DATA_NASCIM)
            $scope.sexo = paci.SEXO
            $scope.rg = paci.RG
            $scope.estadocivil = paci.EST_CIVIL
            $scope.profissao = paci.PROFISSAO
            $scope.pai = paci.NOMEPAI
            $scope.mae = paci.NOMEMAE
            $scope.convenio = paci.CONVENIO
            $scope.plano = paci.CONVENIO_PLANO
            $scope.carteirinha = paci.NRCONVENIO
            $scope.titular = paci.TITULAR
            $scope.validade_cart = new Date(paci.CONVENIO_VALIDADE_CARTEIRA)
            $scope.cep = paci.CEP
            $scope.bairro = paci.BAIRRO
            $scope.celular = paci.Celular
            $scope.telefone = paci.FONERESID.substring(1,12).replace(' ','')
            $scope.email = paci.EMAIL

            $scope.BuscarCEP()
        }
    })
})

