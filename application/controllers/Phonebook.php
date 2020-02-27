<?php

defined('BASEPATH') OR exit('No direct script access allowed');

class Phonebook extends CI_Controller {

  var $TPL;

  public function __construct()
  {
    parent::__construct();

    $this->TPL['update'] = false;
    $this->TPL['newentry'] = false;
  }

  private function display()
  {
    $query = $this->db-> query("SELECT * FROM phonebook ORDER BY id ASC;");
    $this->TPL['listing'] = $query->result_array();

    $this->load->view('phonebook_view', $this->TPL);
  }

  public function index()
  {
    $this->display();
  }

  public function delete($id)
  {
    $query = $this->db->query("DELETE FROM phonebook where id = '$id';");

    $this->display();
  }

  public function newentry()
  {
    $fname = $this->input->post("fname");
    $lname = $this->input->post("lname");
    $phone = $this->input->post("phone");
    $email = $this->input->post("email");
    $query = $this->db->query("INSERT INTO phonebook VALUES (NULL, '$fname', '$lname', '$phone', '$email', NULL, NULL, NULL, NULL);");

    $this->display();

  }

  public function addnew()
  {
    $this->TPL['newentry'] = TRUE;

    $this->display();
  }

  public function update($id)
  {
    $query = $this->db->query("SELECT * FROM phonebook where id = '$id';");
    $this->TPL['entry'] = $query->result_array()[0];

    $this->TPL['update'] = true;

    $this->display();
  }

  public function updateentry($id)
  {
    $fname = $this->input->post("fname");
    $lname = $this->input->post("lname");
    $phone = $this->input->post("phone");
    $email = $this->input->post("email");
    $query = $this->db->query("UPDATE phonebook " .
                              "SET fname = '$fname'," .
                              "    lname = '$lname'," .
                              "    phone = '$phone'," .
                              "    email = '$email'" .
                              " WHERE id = '$id';");
    $this->display();
  }

}
