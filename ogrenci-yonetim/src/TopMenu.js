import React, { Component } from "react";
import {
  Collapse,
  Navbar,
  NavbarToggler,
  NavbarBrand,
  Nav,
  NavItem,
  NavLink,
  UncontrolledDropdown,
  DropdownToggle,
  DropdownMenu,
  DropdownItem
} from "reactstrap";
// const data = [
//   {
//     key: "1",
//     firstName: "John",
//     lastName: "Brown",
//     age: 32,
//     address: "New York No. 1 Lake Park",
//     tags: ["nice", "developer"]
//   },
//   {
//     key: "2",
//     firstName: "Jim",
//     lastName: "Green",
//     age: 42,
//     address: "London No. 1 Lake Park",
//     tags: ["loser"]
//   },
//   {
//     key: "3",
//     firstName: "Joe",
//     lastName: "Black",
//     age: 32,
//     address: "Sidney No. 1 Lake Park",
//     tags: ["cool", "teacher"]
//   }
// ];
export default class TopMenu extends Component {
  constructor(props) {
    super(props);

    this.toggle = this.toggle.bind(this);
    this.state = {
      isOpen: false
    };
  }
  toggle() {
    this.setState({
      isOpen: !this.state.isOpen
    });
  }
  render() {
    return (
      <div>
        {/* <Button onClick={()=> this.props.onClickChange(data)} type="danger">
          Danger
        </Button> */}

        <Navbar color="light" light expand="md">
          {/*Props ve Encapsulations çalışmalar */}
          <NavbarBrand href="/" >{this.props.infoMenu[1]}</NavbarBrand>
          <NavbarToggler onClick={this.toggle} />
          <Collapse isOpen={this.state.isOpen} navbar>
            <Nav className="ml-auto" navbar>
              <NavItem>
                {/*Props ve Encapsulations çalışmalar */}
                <NavLink onClick={()=>{this.props.onClickChange(1)}} > {this.props.infoMenu[2]}</NavLink>
              </NavItem>
              <NavItem>
                <NavLink onClick={()=>{this.props.onClickChange(2)}} >{this.props.infoMenu[3]}</NavLink>
              </NavItem>
              {/* <UncontrolledDropdown nav inNavbar>
                <DropdownToggle nav caret>
                  mi
                </DropdownToggle>
                <DropdownMenu right>
                  <DropdownItem > la </DropdownItem>
                  <DropdownItem> sol</DropdownItem>
                  <DropdownItem divider />
                  <DropdownItem> fa</DropdownItem>
                </DropdownMenu>
              </UncontrolledDropdown> */}
            </Nav>
          </Collapse>
        </Navbar>
      </div>
    );
  }
}
