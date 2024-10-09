#!/usr/bin/env python

"""
Add mock data to the database.
"""

import random
import sys
from dataclasses import dataclass

from mysql.connector import connect
import numpy
from PIL import Image
from faker import Faker

GENDER = ("Male", "Female")
RELIGION = ("Catholic", "Born Again", "Protestant", "Buddhist", "Hindu", "Islam")


@dataclass
class Student:
    student_number: str
    name: tuple[str, str, str]
    photo: bytes

    gender: str
    birth_date: str
    birth_address: str
    nationality: str
    citizenship: str
    religion: str

    contact_number: str
    email_address: str

    present_address_line1: str
    present_address_line2: str
    present_address_zip_code: str

    permanent_address_line1: str
    permanent_address_line2: str
    permanent_address_zip_code: str

    mother_name: str
    mother_occupation: str
    mother_contact_number: str
    mother_address: str

    father_name: str
    father_occupation: str
    father_contact_number: str
    father_address: str

    guardian_name: str
    guardian_occupation: str
    guardian_contact_number: str
    guardian_address: str

    last_school_attended: str
    last_school_attended_year: int
    secondary_school: str
    secondary_school_year: int
    awards_received: str

    hobbies: str
    skills: str


def generate_image_from_noise() -> bytes:
    """
    Generate a random image from noise.

    :return bytes: The image data.
    """

    a = numpy.random.rand(30, 30, 3) * 255
    im_out = Image.fromarray(a.astype("uint8")).convert("RGB")
    return im_out.tobytes()


def main(
    n: int,
    host: str = "localhost",
    port: int = 3306,
    db: str = "bu_student_information_system",
    user: str = "root",
    passwd: str | None = None,
) -> int:
    """
    The entry point of the script.

    :param int n: The number of students to add.
    :return int: The exit code.
    """

    f = Faker()

    print(f"Adding {n} students to database...")
    sn: list[str] = []
    students: list[Student] = []
    for _ in range(n):
        while True:
            student_number = f"{random.randint(100, 999)}-{random.randint(1000, 9999)}"
            if student_number not in sn:
                sn.append(student_number)
                break

        nat_cit = f.country()
        student = Student(
            student_number=student_number,
            name=(f.first_name(), f.last_name(), f.last_name()),
            photo=generate_image_from_noise(),
            # PersonalInformation
            gender=random.choice(GENDER),
            birth_date=str(
                f.date_of_birth(minimum_age=15, maximum_age=22, pattern="%Y-%m-%d")
            ),
            birth_address=f.address(),
            nationality=nat_cit,
            citizenship=nat_cit,
            religion=random.choice(RELIGION),
            # ContactInformation
            contact_number=f.phone_number(),
            email_address=f.email(),
            # AddressInformation
            present_address_line1=f.address(),
            present_address_line2=f.address(),
            present_address_zip_code=f.zipcode(),
            permanent_address_line1=f.address(),
            permanent_address_line2=f.address(),
            permanent_address_zip_code=f.zipcode(),
            # FamilyInformation
            mother_name=f.name(),
            mother_occupation=f.job(),
            mother_contact_number=f.phone_number(),
            mother_address=f.address(),
            father_name=f.name(),
            father_occupation=f.job(),
            father_contact_number=f.phone_number(),
            father_address=f.address(),
            guardian_name=f.name(),
            guardian_occupation=f.job(),
            guardian_contact_number=f.phone_number(),
            guardian_address=f.address(),
            # PersonalityInformation
            last_school_attended=f.company(),
            last_school_attended_year=random.randint(2010, 2020),
            secondary_school=f.company(),
            secondary_school_year=random.randint(2010, 2020),
            awards_received=f.sentence(),
            # Personalities
            hobbies=f.sentence(),
            skills=f.sentence(),
        )
        students.append(student)

    print("Connecting to database...")
    with connect(
        host=host,
        port=port,
        user=user,
        password=passwd,
        database=db,
    ) as conn:
        with conn.cursor() as cur:
            for idx, student in enumerate(students):
                print(f"Adding student {student.student_number}... [{idx + 1}/{n}]")
                cur.execute(
                    """\
    INSERT INTO students (
    student_number, name_first, name_middle,
    name_last, photo, gender, birth_date,
    birth_address, nationality, citizenship, religion)
    VALUES (%s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s)""",
                    (
                        student.student_number,
                        student.name[0],
                        student.name[1],
                        student.name[2],
                        student.photo,
                        student.gender,
                        student.birth_date,
                        student.birth_address,
                        student.nationality,
                        student.citizenship,
                        student.religion,
                    ),
                )
                cur.execute(
                    """\
    INSERT INTO contact_information (
    id, contact_number, email_address)
    VALUES (%s, %s, %s)""",
                    (
                        student.student_number,
                        student.contact_number,
                        student.email_address,
                    ),
                )
                cur.execute(
                    """\
    INSERT INTO present_addresses (
    id, line1, line2, zip_code)
    VALUES (%s, %s, %s, %s)""",
                    (
                        student.student_number,
                        student.present_address_line1,
                        student.present_address_line2,
                        student.present_address_zip_code,
                    ),
                )
                cur.execute(
                    """\
    INSERT INTO permanent_addresses (
    id, line1, line2, zip_code)
    VALUES (%s, %s, %s, %s)""",
                    (
                        student.student_number,
                        student.permanent_address_line1,
                        student.permanent_address_line2,
                        student.permanent_address_zip_code,
                    ),
                )
                cur.execute(
                    """\
    INSERT INTO student_family (
    id, mother_name, mother_occupation,
    mother_contact_number, mother_address,
    father_name, father_occupation,
    father_contact_number, father_address,
    guardian_name, guardian_occupation,
    guardian_contact_number, guardian_address)
    VALUES (%s,
    %s, %s, %s, %s,
    %s, %s, %s, %s,
    %s, %s, %s, %s)""",
                    (
                        student.student_number,
                        student.mother_name,
                        student.mother_occupation,
                        student.mother_contact_number,
                        student.mother_address,
                        student.father_name,
                        student.father_occupation,
                        student.father_contact_number,
                        student.father_address,
                        student.guardian_name,
                        student.guardian_occupation,
                        student.guardian_contact_number,
                        student.guardian_address,
                    ),
                )
                cur.execute(
                    """\
    INSERT INTO academic_history (
    id, last_school_attended, last_school_attended_year,
    secondary_school, secondary_school_year, awards_received)
    VALUES (%s, %s, %s, %s, %s, %s)""",
                    (
                        student.student_number,
                        student.last_school_attended,
                        student.last_school_attended_year,
                        student.secondary_school,
                        student.secondary_school_year,
                        student.awards_received,
                    ),
                )
                cur.execute(
                    """\
    INSERT INTO personalities (
    id, hobbies, skills)
    VALUES (%s, %s, %s)""",
                    (
                        student.student_number,
                        student.hobbies,
                        student.skills,
                    ),
                )
        conn.commit()

    return 0


if __name__ == "__main__":
    try:
        n = int(sys.argv[1])
    except IndexError:
        n = 100  # Default number of students to add

    sys.exit(main(n))
