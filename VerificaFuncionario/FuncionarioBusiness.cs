using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerificaFuncionario
{
    public class FuncionarioBusiness
    {
        public static void Funcionarios()
        {
            var funcionarios = new List<FuncionarioEntity>();

            while (true)
            {
                FuncionarioEntity pessoas = new FuncionarioEntity();

                Console.WriteLine("Digite o Nome do funcionário:");
                pessoas.Nome = Console.ReadLine();


                try//se não digitar correto vai pro catch
                {
                    while (true)
                    {
                        Console.WriteLine("Digite o Idade do funcionário:");
                        pessoas.Idade = int.Parse(Console.ReadLine());
                        if (pessoas.Idade < 14)
                        {
                            Console.WriteLine("Digite o Idade do funcionário:");
                            pessoas.Idade = int.Parse(Console.ReadLine());

                        }
                        if (pessoas.Idade >= 14)
                        {
                            break;
                        }
                    }
                }
                catch (FormatException ex)
                {
                    while (true)
                    {
                        Console.WriteLine("Erro em sua entrada, pois não é um número ou a idade é inapropriada para ser funcionário!");
                        Console.WriteLine("Digite o Idade do funcionário:");
                        pessoas.Idade = int.Parse(Console.ReadLine());
                        if (pessoas.Idade >= 14)
                        {
                            break;
                        }
                    }

                }


                Console.WriteLine("Digite o CPF do funcionário(somente os números):");
                pessoas.CPF = Console.ReadLine();
                var total = pessoas.CPF.Count(); // outra forma pessoas.CPF.Length

                while (total <= 10 || total > 11 || pessoas.CPF.Any(char.IsLetter))
                {
                    Console.WriteLine("CPF invalido ");
                    Console.WriteLine("Digite o CPF do funcionário(somente os números):");
                    pessoas.CPF = Console.ReadLine();
                    total = pessoas.CPF.Count();
                }

                funcionarios.Add(pessoas);

                Console.WriteLine("Digite s para adicionar mais itens:");
                var adicionar = Console.ReadLine();

                if (adicionar != "s" && adicionar != "S")
                {
                    break;
                }


            }
            //usando foreach

            var FuncionarioMaior = new FuncionarioEntity();
            FuncionarioMaior.Idade = 0;

            var FuncionarioMenor = new FuncionarioEntity();
            FuncionarioMenor.Idade = 0;

            foreach (var Item in funcionarios)
            {
                if (Item.Idade > FuncionarioMaior.Idade)
                {
                    FuncionarioMaior = Item;
                }
                if (Item.Idade < FuncionarioMenor.Idade || FuncionarioMenor.Idade == 0)
                {
                    FuncionarioMenor = Item;
                }
            }

            Console.WriteLine($"Lista:\nSeu nome é {FuncionarioMaior.Nome}\nSua idade é {FuncionarioMaior.Idade} sendo o mais velho da lista\nSeu cpf: {FuncionarioMaior.CPF}\nSeu nome é {FuncionarioMenor.Nome}\nSua idade é {FuncionarioMenor.Idade} sendo o mais novo da lista\nSeu cpf:{FuncionarioMenor.CPF}\n\n");


            Console.ReadLine();
        }
    }
}
