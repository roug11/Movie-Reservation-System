package com.example.theatre.api.dto;

import com.example.theatre.persistence.entity.Theatre;
import lombok.Builder;
import lombok.Getter;

@Builder
@Getter
public class TheatreRequestDto {
    private String name;
    private String address;

    public TheatreRequestDto() {
    }

    public Theatre mapToEntity() {
        Theatre theatre = new Theatre();
        theatre.setName(getName());
        theatre.setAddress(getAddress());
        return theatre;
    }
}
