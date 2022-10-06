create database patient_management

use patient_management

create table patient(
	id varchar(15) primary key,
	identity_number varchar(15) not null,
	full_name nvarchar(150) not null,
	address nvarchar(150) not null
)

create table doctor(
	id varchar(15) primary key,
	full_name nvarchar(150),
)

create table medical_examination(
	patient_id varchar(15) not null,
	doctor_id varchar(15) not null,
	exam_date date not null,
	note text,

	constraint pk_medical_exam primary key(patient_id, doctor_id),
	constraint fk_medical_exam_patient foreign key(patient_id) references patient(id),
	constraint fk_medical_exam_doctor foreign key(doctor_id) references doctor(id)
)

select * from doctor

select * from patient where id not in(select patient_id from medical_examination)

select patient_id from medical_examination

