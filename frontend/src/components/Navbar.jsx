import { Link } from "react-router-dom";

const Navbar = () => {
  return (
    <nav className="navbar">
      <Link to="/" className="logo">AI Tools Hub</Link>
      <ul>
        <li><Link to="/">Home</Link></li>
        <li><Link to="/category/productivity">Productivity</Link></li>
        <li><Link to="/category/video">Video Tools</Link></li>
      </ul>
    </nav>
  );
};

export default Navbar;
