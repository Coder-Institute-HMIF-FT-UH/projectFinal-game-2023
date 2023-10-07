using UnityEngine;

public enum NodeStates
{
Locked,     // Status node terkunci
Visited,    // Status node sudah dikunjungi
Attainable  // Status node dapat dicapai
}

public enum NodeType
{
BattleEnemy,
RestSite,
Boss,
}

public class Node
{
public string Name { get; set; }
public NodeStates State { get; set; }
public NodeType Type { get; set; }

public Node(string name, NodeType type)
{
    Name = name;
    State = NodeStates.Locked;
    Type = type;
}

public void Visit()
{
    State = NodeStates.Visited;
    Debug.Log($"Anda telah mengunjungi node {Name}.");
}

public void Unlock()
{
    State = NodeStates.Attainable;
    Debug.Log($"Node {Name} telah dibuka.");
}
}

public class Map : MonoBehaviour
{
    
    void Start()
    {
        System.Random random = new System.Random();
        Node[] nodes = new Node[10]; // Jumlah node yang diinginkan
        for (int i = 0; i < nodes.Length; i++)
        {
            int randomNodeType = random.Next(2); // Sementara 0 untuk BattleEnemy, 1 untuk RestSite
            NodeType nodeType = (NodeType)randomNodeType;
            nodes[i] = new Node($"Node {i + 1}", nodeType);
        }

        // Simulasi mengunjungi dan membuka node
        foreach (var node in nodes)
        {
            if (node.State == NodeStates.Locked)
            {
                Debug.Log($"Pilihan Anda di {node.Name}:");
                Debug.Log("1. Battle Area");
                Debug.Log("2. Rest Area");

                int choice = GetUserChoice();

                if (choice == 1)
                {
                    if (node.Type == NodeType.BattleEnemy)
                    {
                        node.Unlock();
                    }
                    else
                    {
                        Debug.Log("Anda memilih Battle Area di node Rest Site.");
                    }
                }
                else if (choice == 2)
                {
                    if (node.Type == NodeType.RestSite)
                    {
                        node.Unlock();
                    }
                    else
                    {
                        Debug.Log("Anda memilih Rest Area di node Battle Enemy.");
                    }
                }
                else
                {
                    Debug.Log("Pilihan tidak valid.");
                }
            }
            else if (node.State == NodeStates.Visited)
            {
                Debug.Log($"Anda telah mengunjungi node {node.Name} sebelumnya.");
            }
            else if (node.State == NodeStates.Attainable)
            {
                Debug.Log($"Node {node.Name} telah dibuka.");
            }
        }
    }

    int GetUserChoice()
    {
        int choice = 0;
        bool validInput = false;

        /*while (!validInput)
        {
            string input = UnityEngine.Input.inputString;

            if (int.TryParse(input, out choice) && (choice == 1 || choice == 2))
            {
                validInput = true;
            }
            else
            {
                Debug.Log("Pilihan tidak valid. Masukkan 1 untuk Battle Area atau 2 untuk Rest Area.");
            }
        }*/

        return choice;
    }
}
