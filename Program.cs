using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Cria a suíte
Suite suite1 = new Suite(tipoSuite: "Deluxe", capacidade: 4, valorDiaria: 50);
Suite suite2 = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);
Suite suite3 = new Suite(tipoSuite: "Standard", capacidade: 2, valorDiaria: 20);

List<Suite> listSuites = new List<Suite>(){suite1,  suite2, suite3 };

Console.WriteLine("Escolha a sua suite: ");
Console.WriteLine($"1 - {listSuites[0].TipoSuite} | Capacidade: {listSuites[0].Capacidade} | Valor diária: {listSuites[0].ValorDiaria}");
Console.WriteLine($"2 - {listSuites[1].TipoSuite} | Capacidade: {listSuites[1].Capacidade} | Valor diária: {listSuites[1].ValorDiaria}");
Console.WriteLine($"3 - {listSuites[2].TipoSuite} | Capacidade: {listSuites[2].Capacidade} | Valor diária: {listSuites[2].ValorDiaria}");

int selectedSuite = int.Parse(Console.ReadLine());

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();

int contador = 1;
do
{
    Console.WriteLine("\nInforme os dados do hospede:");
    Console.WriteLine("Nome:");
    string nome = Console.ReadLine();
    Console.WriteLine("Sobrenome:");
    string sobrenome = Console.ReadLine();
    Pessoa hospede = new Pessoa(nome, sobrenome);
    hospedes.Add(hospede);

    Console.WriteLine("\nDeseja cadastrar um novo hospede?\n1 - Sim \n0 - Não");
    contador = int.Parse(Console.ReadLine());    
} while (contador  == 1);

Console.WriteLine("\nDigite quantos dias deseja permanecer hospedado: ");
int days = int.Parse(Console.ReadLine());

// Cria uma nova reserva, passando a suíte e os hóspedes
Reserva reserva = new Reserva(days);
reserva.CadastrarSuite(listSuites[selectedSuite - 1]);
reserva.CadastrarHospedes(hospedes);

// Exibe a quantidade de hóspedes e o valor da diária
Console.WriteLine($"\nHóspedes: {reserva.ObterQuantidadeHospedes()}");
foreach(var h in hospedes){
    Console.WriteLine($"Nome: {h.NomeCompleto}");
};
Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");
