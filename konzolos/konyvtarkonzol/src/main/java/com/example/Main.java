package com.example;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.SQLException;

public class Main {
    public void main(String[] args) {

        if (args.length == 0) {
            System.out.println("Kérem, adjon meg adatokat.");
            return;
        }

        String filePath = args[0];

        try {
            Connection conn = DriverManager.getConnection("jdbc:mysql://localhost:3306/konyvtar");
            PreparedStatement stmt = conn.prepareStatement("INSERT INTO Kolcsonzok (id, nev, szulIdo) VALUES (?, ?, ?)");

            try (BufferedReader reader = new BufferedReader(new FileReader(filePath))) {
                String line;
                int numberOfImportedRows = 0;
                while ((line = reader.readLine()) != null) {
                    String[] data = line.split(",");
                    stmt.setInt(1, Integer.parseInt(data[0]));
                    stmt.setString(2, data[1]);
                    stmt.setString(3, data[2]);
                    stmt.executeUpdate();
                    numberOfImportedRows++;
                    System.out.println("Sikeresen importálva " + numberOfImportedRows + " sor a Kolcsonzok.csv fájlból.");
                }
            } catch (IOException e) {
                System.out.println("Hiba a Kolcsonzok.csv beolvasása közben: " + e.getMessage());
            }

            stmt.close();
            conn.close();

        } catch (SQLException e) {
            System.out.println("Hiba a Kolcsonzok.csv importálása közben: " + e.getMessage());
        }

        try {
            Connection conn = DriverManager.getConnection("jdbc:mysql://localhost:3306/konyvtar");
            PreparedStatement stmt = conn.prepareStatement("INSERT INTO Kolcsonzesek (id, kolcsonzokId, iro, mufaj, cim) VALUES (?, ?, ?, ?, ?)");

            try (BufferedReader reader = new BufferedReader(new FileReader(filePath))) {
                String line;
                int numberOfImportedRows = 0;
                while ((line = reader.readLine()) != null) {
                    String[] data = line.split(",");
                    stmt.setInt(1, Integer.parseInt(data[0]));
                    stmt.setString(2, data[1]);
                    stmt.setString(3, data[2]);
                    stmt.executeUpdate();
                    numberOfImportedRows++;
                    System.out.println("Sikeresen importálva " + numberOfImportedRows + " sor a Kolcsonzok.csv fájlból.");
                }
            } catch (IOException e) {
                System.out.println("Hiba a Kolcsonzok.csv beolvasása közben: " + e.getMessage());
            }

            stmt.close();
            conn.close();


        } catch (SQLException e) {
            System.out.println("Hiba a Kolcsonzok.csv importálása közben: " + e.getMessage());
        }
    }    
}