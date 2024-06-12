package com.example.theatre.api.dto;

import com.example.theatre.persistence.entity.Theatre;
import lombok.Builder;

@Builder
public class TheatreRequestDto {
    private String name;
    private String address;

    public TheatreRequestDto() {
    }

    public TheatreRequestDto(String name, String address) {
        this.name = name;
        this.address = address;
    }

    public String getAddress() {
        return address;
    }

    public String getName() {
        return name;
    }

    public Theatre mapToEntity() {
        Theatre theatre = new Theatre();
        theatre.setName(getName());
        theatre.setAddress(getAddress());
        return theatre;
    }
}
