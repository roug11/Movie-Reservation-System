package com.example.theatre.persistence.entity;


import com.example.theatre.api.dto.TheatreRequestDto;
import com.fasterxml.jackson.annotation.JsonSubTypes;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.Id;
import lombok.Data;

@Entity
@Data
public class Theatre {
    @Id
    @GeneratedValue
    private Long id;
    private String name;
    private String address;

}
