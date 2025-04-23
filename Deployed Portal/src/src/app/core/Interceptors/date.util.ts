// date.util.ts
export function formatDate(date: Date | string | null | undefined): string {
    if (!date) return 'Invalid Date'; // Handle null or undefined
  
    const parsedDate = new Date(date);
    if (isNaN(parsedDate.getTime())) return 'Invalid Date'; // Handle invalid dates
  
    const day = String(parsedDate.getDate()).padStart(2, '0');
    const month = String(parsedDate.getMonth() + 1).padStart(2, '0');
    const year = parsedDate.getFullYear();
    return `${day}/${month}/${year}`;
  }