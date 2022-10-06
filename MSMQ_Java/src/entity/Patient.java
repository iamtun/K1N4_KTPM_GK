/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package entity;

import java.io.Serializable;
/**
 *
 * @author Le Tuan
 */
//@XmlRootElement(name = "patient")
//@XmlType(propOrder = {
//    "address",
//    "fullName",
//    "id",
//    "identityNumber"
//})
public class Patient implements Serializable{
    private String id;
    private String identityNumber;
    private String fullName;
    private String address;

    public Patient(String id, String identityNumber, String fullName, String address) {
        this.id = id;
        this.identityNumber = identityNumber;
        this.fullName = fullName;
        this.address = address;
    }

    public Patient() {
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getIdentityNumber() {
        return identityNumber;
    }

    public void setIdentityNumber(String identityNumber) {
        this.identityNumber = identityNumber;
    }

    public String getFullName() {
        return fullName;
    }

    public void setFullName(String fullName) {
        this.fullName = fullName;
    }

    public String getAddress() {
        return address;
    }

    public void setAddress(String address) {
        this.address = address;
    }

    @Override
    public String toString() {
        return "Patient{" + "id=" + id + ", identityNumber=" + identityNumber + ", fullName=" + fullName + ", address=" + address + '}';
    }

    
}
