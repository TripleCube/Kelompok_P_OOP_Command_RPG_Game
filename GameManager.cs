using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Player player;
    private List<Enemy> enemies;
    private bool isGameOver = false;

    void Start()
    {
        InitializeGame();
    }

    void Update()
    {
        if (!isGameOver)
        {
            ShowOptions();
        }
    }

    void InitializeGame()
    {
        player = new Player("Guardian");
        enemies = new List<Enemy>();
        Console.WriteLine("Selamat datang di Celestial Realms: Rise of the Guardians!");
        Console.WriteLine("Dunia dipenuhi kegelapan, dan Anda, seorang Guardian muda, memiliki tugas untuk menyelamatkan dunia.");
    }

    void ShowOptions()
    {
        Console.WriteLine("\nPilih Aksi Anda:");
        Console.WriteLine("1. Jelajahi Dunia");
        Console.WriteLine("2. Periksa Status");
        Console.WriteLine("3. Periksa Inventori");
        Console.WriteLine("4. Simpan dan Keluar");

        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                Explore();
                break;
            case "2":
                player.DisplayStatus();
                break;
            case "3":
                player.ShowInventory();
                break;
            case "4":
                isGameOver = true;
                Console.WriteLine("Permainan Berakhir. Terima kasih telah bermain!");
                break;
            default:
                Console.WriteLine("Pilih opsi yang benar!");
                break;
        }
    }

    void Explore()
    {
        Console.WriteLine("Anda sedang menjelajahi dunia...");
        // Event eksplorasi sederhana atau pertarungan acak
        if (UnityEngine.Random.value > 0.5f)
        {
            StartBattle(new Enemy("Goblin", 50, 10, 5));
        }
        else
        {
            Console.WriteLine("Anda menemukan item Potion!");
            player.AddItem(new Item("Potion", 20, "Memulihkan HP"));
        }
    }

    void StartBattle(Enemy enemy)
    {
        Console.WriteLine($"Pertarungan dimulai melawan {enemy.Name}!");
        BattleManager.StartBattle(player, enemy);
    }
}
